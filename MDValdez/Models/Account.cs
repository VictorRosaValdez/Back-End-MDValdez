using Microsoft.EntityFrameworkCore;

namespace MDValdez.Models
{
    public abstract class Account
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
