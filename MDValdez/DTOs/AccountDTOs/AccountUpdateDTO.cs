using MDValdez.Models;

namespace MDValdez.DTOs.AccountDTOs
{
    public class AccountUpdateDTO
    {
        public int AccountId { get; set; }
        public string CustomerName { get; set; }
        public string adress { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
