using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.AspectOrientedPrograming;
using StudentManagementSystem.Constants;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [ServiceFilter(typeof(ExceptionHandlerAttribute))]
    public class CourseController : Controller
    {
        readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            return View(await _courseService.GetAllCoursesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseById(int id)
        {
            Course course = await _courseService.GetCourseByIdAsync(id);
            if (course != null)
            {
                return View(await _courseService.GetCourseByIdAsync(id));
            }
            TempData["message"] = "Book Not Found";
            return View();

        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> AddCourse()
        {
            return View();
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            ModelState.Remove("Enrollments");
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            int result = await _courseService.AddCourseAsync(course);
            if (result > 0)
            {
                return RedirectToAction("GetAllCourses");
            }
            return View(course);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            Course course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                TempData["msg"] = "Book not found";
                return View(course);
                //return RedirectToAction("GetAllBooks");
            }
            return View(course);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> DeleteCourse(Course course)
        {

            int deleteResult = await _courseService.DeleteCourseAsync(course.CourseId);

            if (deleteResult > 0)
            {
                return RedirectToAction("GetAllCourses");
            }
            else
            {

                TempData["msg"] = "Book not found";
                return View(course);
            }

        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> UpdateCourse(int id, string? returnUrl)
        {
            Course courseExist = await _courseService.GetCourseByIdAsync(id);
            if (courseExist == null)
            {
                TempData["Updatemsg"] = "Student not found";
                return View();
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(courseExist);
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> UpdateCourse(Course course, string? returnUrl)
        {
            //Book bookExist = await _bookService.GetBookById(book.BookId);
            int updateditem = await _courseService.UpdateCourseAsync(course);
            if (updateditem > 0)
            {
                TempData["Updatemsg"] = "Data Updated";
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("GetAllCourses");
            }
            else
            {

                TempData["Updatemsg"] = "Book not found";
                return View(course);
            }

        }
    }
}
