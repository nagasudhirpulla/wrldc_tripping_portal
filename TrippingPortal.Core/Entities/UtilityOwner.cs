using TrippingPortal.Core.Interfaces;

namespace TrippingPortal.Core.Entities
{
    /**
     * Many-Many relation between Utility and Owner
     * **/
    public class UtilityOwner : BaseEntity, IAggregateRoot
    {
        public Utility Utility { get; set; }
        public string UtilityId { get; set; }
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
