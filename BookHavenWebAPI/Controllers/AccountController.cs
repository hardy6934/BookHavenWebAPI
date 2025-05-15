using AutoMapper;
using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookHavenWebAPI.Controllers
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
        /// Get account
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountAsync()
        {
            var emailClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

            var dto = await accountService.GetAccountByEmailAsync(emailClaim);

            return dto is not null ? Ok(mapper.Map<AccountResponseModel>(dto)) : NotFound(); 
        } 
    }
}
