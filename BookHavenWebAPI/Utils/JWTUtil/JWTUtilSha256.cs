using BookHaven.Core.Abstractions;
using BookHaven.Core.DataTransferObjects;
using BookHaven.Models.ResponseModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookHaven.Utils.JWTUtil
{
    public class JWTUtilSha256: IJWTUtil
    {
        private readonly IConfiguration configuration;
        private readonly IAccountService accountService;

        public JWTUtilSha256(IConfiguration configuration, IAccountService accountService)
        {
            this.configuration = configuration;
            this.accountService = accountService;
        }

        public TokenResponseModel GenerateToken(AccountDTO dto)
        {  
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:JWTSecret"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var nowUtc = DateTime.UtcNow;
            var expire = nowUtc.AddMinutes(double.Parse(configuration["Token:ExpiryMinutes"])).ToUniversalTime();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, dto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("D")),
                new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString("D"))
            };

            var JWTToken = new JwtSecurityToken(configuration["Token:Issuer"],
                configuration["Token:Issuer"],
                claims,
                expires: expire,
                signingCredentials: credentials);

            var accestoken = new JwtSecurityTokenHandler().WriteToken(JWTToken);

            return new TokenResponseModel()
            {
                AccesToken = accestoken,
                TokenExp = JWTToken.ValidTo,
                AccountId = dto.Id
            };
        }
    }
}
