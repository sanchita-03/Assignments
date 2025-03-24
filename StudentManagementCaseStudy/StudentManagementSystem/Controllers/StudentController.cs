using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Constants;
using StudentManagementSystem.ViewModels;
using StudentManagementSystem.Context;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.AspectOrientedPrograming;


namespace StudentManagementSystem.Controllers
{
    [ServiceFilter(typeof(ExceptionHandlerAttribute))]
    public class StudentController : Controller
    {
        readonly IStudentService _studentService;
        readonly UserManager<ApplicationUser> _userManager;
        readonly StudentDbContext _context;
        public StudentController(IStudentService studentService, UserManager<ApplicationUser> userManager, StudentDbContext context)
        {
            _studentService = studentService;
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Roles = Role.Student)]
        public IActionResult StudentDashboard()
        {
            return View();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return View(await _studentService.GetAllStudentsAsync());
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentById(int id)
        {
            Student student = await _studentService.GetStudentByIdAsync(id);
            if (student != null)
            {
                return View(await _studentService.GetStudentByIdAsync(id));
            }
            TempData["message"] = "Book Not Found";
            return View();

        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            return View();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddStudent(RegisterViewModel user)
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
                    return RedirectToAction("GetAllStudents");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                TempData["msg"] = "Book not found";
                return View(student);
                //return RedirectToAction("GetAllBooks");
            }
            return View(student);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student student)
        {

            int deleteResult = await _studentService.DeleteStudentAsync(student.StudentId);

            if (deleteResult > 0)
            {
                return RedirectToAction("GetAllStudents");
            }
            else
            {

                TempData["msg"] = "Book not found";
                return View(student);
            }

        }

        [Authorize(Roles = $"{Role.Admin},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> UpdateStudent(int id)
        {
            Student studentExist = await _studentService.GetStudentByIdAsync(id);
            if (studentExist == null)
            {
                TempData["Updatemsg"] = "Student not found";
                return View();
            }
            return View(studentExist);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Student}")]
        [HttpPost]
        public async Task<IActionResult> UpdateStudent(Student student,string returnUrl)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == student.StudentId);
            //Book bookExist = await _bookService.GetBookById(book.BookId);
            var applicationUser = await _userManager.FindByIdAsync(existingStudent.UserId);
            applicationUser.Email = student.Email;
            applicationUser.UserName = student.Email;
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;
            existingStudent.DateOfBirth= student.DateOfBirth;
            var result=await _userManager.UpdateAsync(applicationUser);
            if (result.Succeeded)
            {
                int updateditem = await _studentService.UpdateStudentAsync(existingStudent);
                if (updateditem > 0)
                {
                    TempData["Updatemsg"] = "Data Updated";
                    return !string.IsNullOrEmpty(returnUrl) ? Redirect(returnUrl) : RedirectToAction("GetAllStudents");
                }
                else
                {

                    TempData["Updatemsg"] = "Book not found";
                    return View(student);
                }
            }
            return View(student);

        }
    }
}
