using Microsoft.AspNetCore.Identity;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
