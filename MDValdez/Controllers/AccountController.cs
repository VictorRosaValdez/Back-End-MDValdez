using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
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
        /// Get all products.
        /// </summary>
        /// <response code="200">Succesfully returns a list of products</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountReadDTO>>> GetAllAccounts()
        {
            var domainAccounts = await _account.GetAllAccountsAsync();

            var dtoAccount = _mapper.Map<List<AccountReadDTO>>(domainAccounts.Value);

            return dtoAccount;
        }
    }
}
