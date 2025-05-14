

using BookHavenWebAPI.Core.DataTransferObjects;

namespace BookHavenWebAPI.Core.Abstractions
{
    public interface ICollectionService
    {
        Task<int> CreateCollectionAsync(CollectionDTO dto);
        Task<int> RemoveCollectionAsync(CollectionDTO dto);
        Task<int> UpdateCollectionAsync(CollectionDTO dto);
        Task<CollectionDTO> GetCollectionByIdAsnyc(int id, int accountId);
        Task<bool> IsCollectionExistAsync(string name, int accountId);
        Task<List<CollectionDTO>> GetAllCollectionsAsnyc(int accountId);
        Task<List<CollectionDTO>> GetAllCollectionsForSearchAsnyc(string name, int accountId);
    }
}
