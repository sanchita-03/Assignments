using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Infrastructure.Context;
using TicketBookingSystemApp.Infrastructure.Repository;

namespace TicketBookingSystemApp.Infrastructure
{
    public static class InterfaceServiceRegistration
    {  
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TicketBookingDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("TicketBookingDbConnString"));
            });
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            return services;
        }
        //services.Add
    }
}
