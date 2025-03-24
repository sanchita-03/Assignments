using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentManagementSystem.Exceptions;

namespace StudentManagementSystem.AspectOrientedPrograming
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        readonly ILogger<ExceptionHandlerAttribute> _logger;
        public ExceptionHandlerAttribute(ILogger<ExceptionHandlerAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType() == typeof(StudentNotFoundException))
            {
                //context.Result = new ConflictObjectResult(context.Exception.Message);
                context.Result = new RedirectToActionResult("Error", "Home", new { message = context.Exception.Message });
                context.ExceptionHandled = true;
                _logger.LogError(context.Exception.Message);
            }
            else if(context.Exception.GetType() == typeof(CourseNotFoundException))
            {
                context.Result = new RedirectToActionResult("Error", "Home", new { message = context.Exception.Message });
                context.ExceptionHandled = true;
                _logger.LogError(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(EnrollmentNotFoundException))
            {
                context.Result = new RedirectToActionResult("Error", "Home", new { message = context.Exception.Message });
                context.ExceptionHandled = true;
                _logger.LogError(context.Exception.Message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}
