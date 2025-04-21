using BookHavenWebAPI.Core.DataTransferObjects;

namespace BookHavenWebAPI.Core.Abstractions
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountByEmailAsync(string email);
        Task<AccountDTO> GetAccountByIdAsync(int id);
        Task<int> CreateAccountAsync(AccountDTO dto);
        Task<bool> CheckUserPassword(AccountDTO dto);
    }
}
