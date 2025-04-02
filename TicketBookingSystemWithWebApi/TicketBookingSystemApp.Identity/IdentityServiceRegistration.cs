using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketBookingSystemApp.Application.Interfaces.Identity;
using TicketBookingSystemApp.Identity.Context;
using TicketBookingSystemApp.Identity.Model;
using TicketBookingSystemApp.Identity.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace TicketBookingSystemApp.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketBookingIdentityDbContext>(option =>

                option.UseSqlServer(configuration.GetConnectionString("TicketBookingDbConnString")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<TicketBookingIdentityDbContext>()
                    .AddDefaultTokenProviders();
            services.AddTransient<IAuthService,AuthServices>();
            //services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });
            return services;
        }
    }
}
