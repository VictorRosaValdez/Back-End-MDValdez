using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace MDValdez.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository account, IMapper mapper)
        {
            _account = account;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all accounts.
        /// </summary>
        /// <response code="200">Succesfully returns a list of accounts</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountReadDTO>>> GetAllAccounts()
        {
            var domainAccounts = await _account.GetAllAccountsAsync();

            var dtoAccount = _mapper.Map<List<AccountReadDTO>>(domainAccounts.Value);

            return dtoAccount;
        }

        /// <summary>
        /// Get an account by Id
        /// </summary>
        /// <param name="id">The account Id</param>
        /// <returns>An account object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountReadDTO>> GetAccountById(int id)
        {
            var domainAccount = await _account.GetAccountByIdAsync(id);

            var dtoAccount = _mapper.Map<AccountReadDTO>(domainAccount.Value);

            if (dtoAccount == null)
            {
                return NotFound();
            }

            return dtoAccount;
        }

        /// <summary>
        /// Update an Account.
        /// </summary>
        /// <param name="id">The account Id</param>
        /// <param name="accountDto">AccountDto object</param>
        /// <returns>Action result without content</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAccount(int id, AccountUpdateDTO accountDto)
        {

            if (id != accountDto.AccountId)
            {
                return BadRequest();
            }


            var domainAccount = await _account.PutAccountAsync(id, accountDto);


            if (domainAccount == null)
            {
                return NotFound();
            }

            try
            {
                await _account.PutAccountAsync(id, accountDto);

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Create a new account object.
        /// </summary>
        /// <param name="accountDto">An account DTO object</param>
        /// <returns>An account Read DTO object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(AccountCreateDTO accountDto)
        {

            var domainAccount = _mapper.Map<Customer>(accountDto);


            await _account.PostAccountAsync(domainAccount);

            return domainAccount;
        }

        /// <summary>
        /// Delete an account by Id.
        /// </summary>
        /// <param name="id">Id of the account object</param>
        /// <returns></returns>
        /// <response code="204">Succesfully deleted the account.</response>
        /// <response code="404">Error: The order you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult> DeleteAccountAsync(int id)
        {
            var domainOrder = await _account.DeleteAccountAsync(id);

            if (domainOrder == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
