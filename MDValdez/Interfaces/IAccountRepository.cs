using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDValdez.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Absctract method to get all Accounts.
        /// </summary>
        /// <returns>A list of accountsDto</returns>
        Task<ActionResult<IEnumerable<Account>>> GetAllAccountsAsync();

        /// <summary>
        /// Abstract method to get an account by Id.
        /// </summary>
        /// <returns>A accountDto</returns>
        Task<ActionResult<IEnumerable<Account>>> GetAccountByIdAsync();

    }
}
