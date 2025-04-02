
using Microsoft.EntityFrameworkCore;
using TicketBookingSystemApp.Domain;
using TicketBookingSystemApp.Infrastructure.Configuration;

namespace TicketBookingSystemApp.Infrastructure.Context
{
    public class TicketBookingDbContext : DbContext
    {
        public TicketBookingDbContext(DbContextOptions<TicketBookingDbContext>options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventSeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
            modelBuilder.ApplyConfiguration(new BookingSeedConfiguration());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                        .Property(b => b.Status)
                        .HasConversion<string>();
            modelBuilder.Entity<Event>()
                        .Property(b => b.EventType)
                        .HasConversion<string>();
            modelBuilder.Entity<Payment>()
                        .Property(b => b.Status)
                        .HasConversion<string>();
            modelBuilder.Entity<Payment>()
                        .Property(b => b.PaymentMethod)
                        .HasConversion<string>();
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<BookingSeat> BookingSeats { get; set; }
    }
}
