using AutoMapper;
using BookHaven.Core.Abstractions;
using BookHaven.Core.DataTransferObjects;
using BookHaven.Models.RequestModels;
using BookHaven.Models.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookHaven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;

        public AccountController(IMapper mapper, IAccountService accountService)
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }

        /// <summary>
        /// Register an account
        /// </summary>
        /// <returns>OK</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAccountAsync([FromBody] AccountRequestModel request)
        {
            if (await accountService.GetAccountByEmailAsync(request.Email) != null)
            {
                return StatusCode(409, "User with the same email already exists");
            }

            var resOfCreationId = await accountService.CreateAccountAsync(mapper.Map<AccountDTO>(request));

            return resOfCreationId != 0 ? 
                Ok(mapper.Map<AccountResponseModel>(await accountService.GetAccountByIdAsync(resOfCreationId))) : 
                StatusCode(500, "something went wrong!"); 
        }

        /// <summary>
        /// TESTS
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("{email}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountByEmail(string email)
        { 
            var dto = await accountService.GetAccountByEmailAsync(email);

            return dto is not null ? Ok(mapper.Map<AccountResponseModel>(dto)) : NotFound(); 
        } 
    }
}
