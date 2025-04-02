using System.Net;
using TicketBookingSystemApp.Application.Exceptions;

namespace TicketBookingSystemApp.API.MiddleWare
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task<Task> HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case NotFoundException notFound  : 
                    statusCode = HttpStatusCode.NotFound; 
                    break;
                case BadRequestException badRequestException :
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default :
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            httpContext.Response.StatusCode = (int)statusCode;
            var response = new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message
            };
            return httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
