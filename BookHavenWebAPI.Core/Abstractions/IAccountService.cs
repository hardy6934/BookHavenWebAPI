using BookHaven.Core.DataTransferObjects;

namespace BookHaven.Core.Abstractions
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountByEmailAsync(string email);
        Task<AccountDTO> GetAccountByIdAsync(int id);
        Task<int> CreateAccountAsync(AccountDTO dto);
    }
}
