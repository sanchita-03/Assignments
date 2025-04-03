using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TicketBookingSystemApp.Domain.Constant;

namespace TicketBookingSystemApp.Domain
{
    public class Booking
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Required]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [Required]
        public int EventId { get; set; }
        [JsonIgnore]
        public EventEntity? Event { get; set; }
        [Required]
        public List<int> SeatNumber { get; set; } = new List<int>();
        [Required]
        public DateTime BookingDate { get; set; } = DateTime.Now;
        [Required]
        public Status Status { get; set; } = Status.Pending;
        [JsonIgnore]
        public Payment? Payment { get; set; }
        
    }
}
