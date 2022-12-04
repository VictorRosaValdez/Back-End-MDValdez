using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<OrderReadDTO>>> GetAllAccounts()
        {
            var domainAccounts = await _account.GetAllAccountsAsync();

            var dtoAccount = _mapper.Map<List<OrderReadDTO>>(domainAccounts.Value);

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
    }
}
