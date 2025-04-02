namespace TicketBookingSystemApp.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; }
        //public string Password { get; set; } = string.Empty;
        //public bool RememberMe { get; set; }
    }

}
