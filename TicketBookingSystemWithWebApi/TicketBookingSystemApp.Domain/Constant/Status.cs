using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystemApp.Domain.Constant
{
    public enum Status
    {
        Pending=1,    // Default state
        Confirmed,  // Payment completed & booking confirmed
        Cancelled,  // Booking cancelled by user/admin
        Completed   // Event attended / booking fulfilled
    }
}
