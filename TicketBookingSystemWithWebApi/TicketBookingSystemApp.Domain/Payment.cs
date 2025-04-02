using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystemApp.Domain.Constant;

namespace TicketBookingSystemApp.Domain
{
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Required]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Card;
        [Required]
        public Status Status { get; set; }=Status.Pending;
        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

    }
}
