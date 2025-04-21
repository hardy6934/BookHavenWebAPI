using BookHaven.Core.DataTransferObjects;
using BookHaven.Models.ResponseModels;

namespace BookHaven.Utils.JWTUtil
{
    public interface IJWTUtil
    {
        TokenResponseModel GenerateToken(AccountDTO dto);
    }
}
