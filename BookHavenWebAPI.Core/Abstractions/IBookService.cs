using BookHavenWebAPI.Core.DataTransferObjects;

namespace BookHavenWebAPI.Core.Abstractions
{
    public interface IBookService
    {
        Task<int> CreateBookAsync(BookDTO dto);
        Task<int> RemoveBookAsync(BookDTO dto);
        Task<int> UpdateBookAsync(BookDTO dto);
        Task<BookDTO> GetBookByIdAsnyc(int id);
        Task<bool> IsBookExistAsync(string name);
        Task<List<BookDTO>> GetAllBooksAsnyc();
        Task<List<BookDTO>> GetAllBooksForSearchAsnyc(string name);
    }
}
