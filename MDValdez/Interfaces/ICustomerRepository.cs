using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDValdez.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Absctract method to get all customers.
        /// </summary>
        /// <returns>A list of customersDto</returns>
        Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsync();

        /// <summary>
        /// Abstract method to get a customer by Id.
        /// </summary>
        /// <returns>A customerDto</returns>
        Task<ActionResult<IEnumerable<Customer>>> GetCustomerByIdAsync();

    }
}
