
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TicketBookingSystemApp.Domain
{
    public class BookingSeat
    {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            public int BookingId { get; set; }

            [ForeignKey("BookingId")]
            public Booking Booking { get; set; }

            [Required]
            public int SeatNumber { get; set; }

    }
}
