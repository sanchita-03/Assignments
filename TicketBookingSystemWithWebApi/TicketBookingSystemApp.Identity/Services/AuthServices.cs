using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TicketBookingSystemApp.Application.Constants;
using TicketBookingSystemApp.Application.Exceptions;
using TicketBookingSystemApp.Application.Interfaces.Identity;
using TicketBookingSystemApp.Application.Models.Identity;
using TicketBookingSystemApp.Domain;
using TicketBookingSystemApp.Identity.Model;
using TicketBookingSystemApp.Infrastructure.Context;

namespace TicketBookingSystemApp.Identity.Services
{
    public class AuthServices : IAuthService
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly TicketBookingDbContext _ticketBookingDbContext;
        readonly JwtSettings _jwtSettings;
        public AuthServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TicketBookingDbContext ticketBookingDbContext, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ticketBookingDbContext = ticketBookingDbContext;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user = await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new NotFoundException($"user with Email {authRequest.Email} not found");
            }
            var userPassword = await _signInManager.CheckPasswordSignInAsync(user,authRequest.Password,false);
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            var response = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(roles => new Claim(ClaimTypes.Role, roles)).ToList();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256 );
            var jwtSecurityToken = new JwtSecurityToken
                (
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims : claims ,
                    expires : DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                    signingCredentials : signingCredentials
                );
            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var user = new ApplicationUser
            {
                Email = registrationRequest.Email,
                PhoneNumber = registrationRequest.PhoneNumber,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                UserName = registrationRequest.UserName,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.User);
                var customer = new User
                {
                    UserName = $"{registrationRequest.FirstName} {registrationRequest.LastName}",
                    Email = registrationRequest.Email,
                    PhoneNumber = registrationRequest.PhoneNumber,
                    ApplicationUserId = user.Id
                };
                await _ticketBookingDbContext.Users.AddAsync(customer);
                await _ticketBookingDbContext.SaveChangesAsync();
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                var errorResult = result.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException($"{errorResult}");
            }
        }
    }
}
