using MDValdez.DTOs.AccountDTOs;
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
        /// <returns>An accountDto</returns>
        Task<ActionResult<Account>> GetAccountByIdAsync(int id);

        /// <summary>
        /// Abstract method to get an account by name.
        /// </summary>
        /// <returns>An accountDto</returns>
        Task<ActionResult<Customer>> GetAccountByNameAsync(int id, string name);

        /// <summary>
        /// Absctract method to update an account.
        /// </summary>
        /// <param name="id">Id of the account</param>
        /// <param name="accountDto">AccountDto object</param>
        /// <returns></returns>
        Task<ActionResult<Customer>> PutAccountAsync(int id, AccountUpdateDTO accountDto);

        /// <summary>
        /// Absctract method to add a new account.
        /// </summary>
        /// <param name="account">Account type</param>
        /// <returns>The account object</returns>
        Task<ActionResult<Customer>> PostAccountAsync(Customer customer);

        /// <summary>
        /// Absctract method to delete an account.
        /// </summary>
        /// <param name="id">Id of the account</param>
        /// <returns></returns>
        Task<ActionResult<Account>> DeleteAccountAsync(int id);

    }
}
