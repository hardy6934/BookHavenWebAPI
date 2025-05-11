 

namespace BookHavenWebAPI.Core.DataTransferObjects
{
    public class CollectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int AccountId { get; set; }
        public AccountDTO AccountDTO { get; set; }

        public List<CollectionBookDTO> CollectionBookDTOs { get; set; }
    }
}
