using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.CQS.Commands.RefreshTokenCommands;
using BookHavenWebAPI.Models.ResponseModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookHavenWebAPI.Utils.JWTUtil
{
    public class JWTUtilSha256: IJWTUtil
    {
        private readonly IConfiguration configuration;
        private readonly IRefreshTokenService refreshTokenService;

        public JWTUtilSha256(IConfiguration configuration, IRefreshTokenService refreshTokenService)
        {
            this.configuration = configuration; 
            this.refreshTokenService = refreshTokenService;
        }

        public async Task<TokenResponseModel> GenerateTokenAsync(AccountDTO dto)
        {  
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:JWTSecret"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var nowUtc = DateTime.UtcNow;
            var expire = nowUtc.AddMinutes(double.Parse(configuration["Token:ExpiryMinutes"])).ToUniversalTime();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, dto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("D")),
                new Claim("AccountId", dto.Id.ToString("D"))
            };

            var JWTToken = new JwtSecurityToken(configuration["Token:Issuer"],
                configuration["Token:Issuer"],
                claims,
                expires: expire,
                signingCredentials: credentials);

            var accestoken = new JwtSecurityTokenHandler().WriteToken(JWTToken);

            var refreshTokenDTO = new RefreshTokenDTO()
            {
                Token = Guid.NewGuid(),
                CreationDateTimeUTC = DateTime.UtcNow,
                DeviceName = "Unknown",
                AccountId = dto.Id
            };
            await refreshTokenService.CreateRefreshTokenAsync(refreshTokenDTO);

            return new TokenResponseModel()
            {
                AccesToken = accestoken,
                TokenExp = JWTToken.ValidTo,
                AccountId = dto.Id,
                RefreshToken = refreshTokenDTO.Token
            };
        }
    }
}
