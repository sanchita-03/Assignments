using Microsoft.AspNetCore.Identity;
using TicketBookingSystemApp.API.MiddleWare;
using TicketBookingSystemApp.Application;
using TicketBookingSystemApp.Application.Models.Identity;
using TicketBookingSystemApp.Identity;
using TicketBookingSystemApp.Identity.Context;
using TicketBookingSystemApp.Identity.Model;
using TicketBookingSystemApp.Infrastructure;
namespace TicketBookingSystemApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.AddInterfaceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(x => x
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowAnyHeader());
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
