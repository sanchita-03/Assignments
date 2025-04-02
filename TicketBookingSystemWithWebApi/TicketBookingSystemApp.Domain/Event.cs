using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketBookingSystemApp.Domain.Constant;

namespace TicketBookingSystemApp.Domain
{
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        public int TotalSeats { get; set; }
        [Required]
        public int AvailableSeats { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public EventType EventType { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
