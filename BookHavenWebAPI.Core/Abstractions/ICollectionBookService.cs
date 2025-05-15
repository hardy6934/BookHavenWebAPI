using BookHavenWebAPI.Core.DataTransferObjects;

namespace BookHavenWebAPI.Core.Abstractions
{
    public interface ICollectionBookService
    {
        Task<int> CreateCollectionBookAsync(CollectionBookDTO dto);
        Task<int> RemoveCollectionBookAsync(CollectionBookDTO dto);
        Task<int> UpdateCollectionBookAsync(CollectionBookDTO dto);
        Task<bool> IsCollectionBookExistAsync(int bookId, int collectionId);
        Task<CollectionBookDTO> GetCollectionBookByIdAsnyc(int id, int accountId); 
        Task<List<CollectionBookDTO>> GetAllCollectionBooksInColectionAsnyc(int collectionId, int accountId);
        Task<List<CollectionBookDTO>> GetAllCollectionBooksInColectionForSearchAsnyc(string name, int collectionId, int accountId);
    }
}
