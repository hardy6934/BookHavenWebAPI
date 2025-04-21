using BookHavenWebAPI.Core.DataTransferObjects;

namespace BookHavenWebAPI.Core.Abstractions
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenDTO> GetRefreshTokenByTokenAsNoTrackingAsync(Guid token);
        Task<AccountDTO> GetAccountByRefreshTokensTokenAsNoTrackingAsync(Guid token);
        Task<List<RefreshTokenDTO>> GetAllRefreshTokensForAccountAsNotrackingAsync(int accountId);
        Task<int> CreateRefreshTokenAsync(RefreshTokenDTO refreshTokenDTO);
        Task<int> RemoveRefreshTokenAsync(RefreshTokenDTO refreshTokenDTO);
        Task<int> RemoveRangeRefreshTokenAsync(List<RefreshTokenDTO> refreshTokenDTO);
    }
}
