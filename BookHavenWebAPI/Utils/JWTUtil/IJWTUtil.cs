using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Models.ResponseModels;

namespace BookHavenWebAPI.Utils.JWTUtil
{
    public interface IJWTUtil
    {
        TokenResponseModel GenerateToken(AccountDTO dto);
    }
}
