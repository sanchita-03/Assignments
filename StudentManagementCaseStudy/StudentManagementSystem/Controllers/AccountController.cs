using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Constants;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManger;
        readonly StudentDbContext _context;
        public AccountController(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager,StudentDbContext context)
        {
            _userManager = manager;
            _signInManger = signInManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var createdUser = new ApplicationUser { UserName = user.Email, Email = user.Email };
                var result = await _userManager.CreateAsync(createdUser, user.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(createdUser, Role.Student);
                    var student = new Student
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        DateOfBirth = user.DateOfBirth,
                        UserId = createdUser.Id
                    };

                    _context.Students.Add(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("LogIn");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                var result = await _signInManger.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe,false);
                //var user = _userManager.GetUserAsync(User).Result;
                var isAdmin = user != null && _userManager.IsInRoleAsync(user, "Admin").Result;
                if (result.Succeeded)
                {
                    if (isAdmin)
                    {
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                    return RedirectToAction("StudentDashboard", "Student");
                }
                ModelState.AddModelError("","Invalid Login Info");
            }
            return View(loginModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManger.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
