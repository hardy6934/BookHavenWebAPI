using AutoMapper;
using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Utils.JWTUtil;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BookHavenWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        private readonly IRefreshTokenService refreshTokenService;
        private readonly IJWTUtil jwtUtil;

        public TokenController(IMapper mapper, IAccountService accountService, IJWTUtil jwtUtil, IRefreshTokenService refreshTokenService)
        {
            this.mapper = mapper;
            this.accountService = accountService;
            this.jwtUtil = jwtUtil;
            this.refreshTokenService = refreshTokenService;
        }

        /// <summary>
        /// Create token
        /// </summary>
        /// <returns>OK</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateToken([FromBody] AuthenticationRequestModel request)
        {
            try
            {
                var accountDTO = await accountService.GetAccountByEmailAsync(request.Email);
                if (accountDTO is null) 
                    return NotFound(new { Message = "Login is not exist" });  
                 
                if (await accountService.CheckUserPassword(mapper.Map<AccountDTO>(request)) == false) 
                    return BadRequest(new { Message = "Password is incorrect" }); 


                var response = jwtUtil.GenerateTokenAsync(accountDTO);

                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Revoke token
        /// </summary>
        /// <returns>OK</returns>
        [HttpPost("Revoke")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RevokeToken([FromBody] RefreshTokenRequestModel model)
        {
            try
            {

                var refreshTokenDTO = await refreshTokenService.GetRefreshTokenByTokenAsNoTrackingAsync(model.Token);
                if (refreshTokenDTO is not null)
                {
                    var res = await refreshTokenService.RemoveRefreshTokenAsync(refreshTokenDTO);
                    return Ok("Successfully removed");
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Refresh token
        /// </summary>
        /// <returns>OK</returns>
        [HttpPost("Refresh")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestModel model)
        {
            try
            { 
                var accountDTO = await refreshTokenService.GetAccountByRefreshTokensTokenAsNoTrackingAsync(model.Token);
                var refreshTokenDTO = await refreshTokenService.GetRefreshTokenByTokenAsNoTrackingAsync(model.Token);

                if (accountDTO is not null && refreshTokenDTO is not null)
                {
                    var response = jwtUtil.GenerateTokenAsync(accountDTO);
                    var res = await refreshTokenService.RemoveRefreshTokenAsync(refreshTokenDTO);
                    return Ok(response);
                }
                else return NotFound();

            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }
    }
}
