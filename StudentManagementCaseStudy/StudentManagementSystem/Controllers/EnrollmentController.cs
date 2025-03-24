using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.AspectOrientedPrograming;
using StudentManagementSystem.Constants;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [ServiceFilter(typeof(ExceptionHandlerAttribute))]
    public class EnrollmentController : Controller
    {
        readonly IEnrollmentService _enrollmentService;
        readonly IStudentService _studentService;
        readonly ICourseService _courseService;
        readonly UserManager<ApplicationUser> _userManager;
        readonly StudentDbContext _studentDbContext;
        public EnrollmentController(IEnrollmentService enrollmentService, IStudentService studentService, 
            ICourseService courseService,UserManager<ApplicationUser> userManager,StudentDbContext studentDbContext)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
            _userManager = userManager;
            _studentDbContext = studentDbContext;
        }
        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            //var enrollStudents = await _enrollmentService.GetAllEnrollmentsAsync();
            return View(await _enrollmentService.GetAllEnrollmentsAsync());
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Student}")]
        [HttpGet("Enrollment/GetEnrollmentsByStudentId/{studentId}")]
        public async Task<IActionResult> GetEnrollmentsByStudentId(int studentId)
        {
            var enrollStudents = await _enrollmentService.GetEnrollmentsByStudentIdAsync(studentId);
            return View(enrollStudents);
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet]
        public async Task<IActionResult> EnrollStudent()
        {
            var user = await _userManager.GetUserAsync(User);
            var student = await _studentDbContext.Students.FirstOrDefaultAsync(s => s.UserId == user.Id);

            ViewData["StudentName"] = student.Name;
            ViewData["StudentId"] = student.StudentId;
            ViewData["CourseId"] = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseId", "CourseName");
            return View();
        }
        [Authorize(Roles = Role.Student)]
        [HttpPost]
        public async Task<IActionResult> EnrollStudent(int studentId, int courseId)
        {
            int enrollStudent = await _enrollmentService.EnrollStudentAsync(studentId, courseId);
            ModelState.Remove("Student");
            ModelState.Remove("Course");
            ModelState.Remove("Grade");
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (enrollStudent > 0)
            {
                TempData["EnrollMsg"] = "You Enroll For The Course Successfuly";
                return RedirectToAction("GetEnrollmentsByStudentId",new { studentId = studentId });
            }
            else
            {
                TempData["EnrollMsg"] = "Unsuccessful";
                return View();
            }
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet]
        public async Task<IActionResult> WithdrawStudent(int studentId,int courseId)
        {
            Student student = await _studentService.GetStudentByIdAsync(studentId);
            Course course = await _courseService.GetCourseByIdAsync(courseId);
            if(student==null || course == null)
            {
                TempData["WithdrawMsg"] = "Invalid Student or Course.";
                return View();
            }
            Enrollment enrollment = await _enrollmentService.GetEnrollmentByStudentAndCourseAsync(studentId, courseId);
            return View(enrollment);
        }

        [Authorize(Roles = Role.Student)]
        [HttpPost]
        public async Task<IActionResult> ConfirmWithdrawStudent(int studentId, int courseId)
        {
            ModelState.Remove("Student");
            ModelState.Remove("Course");
            ModelState.Remove("Grade");
            if (!ModelState.IsValid)
            {
                return View();
            }
            int deleteResult = await _enrollmentService.WithdrawStudentAsync(studentId, courseId);
            if (deleteResult > 0)
            {
                TempData["WithdrawMsg"] = "You Withdraw From The Course Successfuly";
                return RedirectToAction("GetEnrollmentsByStudentId", new { studentId = studentId });
            }
            else
            {
                TempData["WithdrawMsg"] = "Unsuccessful";
                return View();
            }
        }
    }
}
