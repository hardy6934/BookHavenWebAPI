

using BookHavenWebAPI.Core.DataTransferObjects;

namespace BookHavenWebAPI.Core.Abstractions
{
    public interface IGenreService
    {
        Task<int> CreateGenreAsync(GenreDTO dto);
        Task<int> RemoveGenreAsync(GenreDTO dto);
        Task<int> UpdateGenreAsync(GenreDTO dto);
        Task<GenreDTO> GetGenreByIdAsnyc(int id);
        Task<bool> IsGenreExistAsync(string name); 
        Task<List<GenreDTO>> GetAllGenresAsnyc();
        Task<List<GenreDTO>> GetAllGenresForSearchAsnyc(string name);
    }
}
