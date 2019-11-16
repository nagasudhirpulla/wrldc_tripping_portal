using TrippingPortal.Core.Interfaces;

namespace TrippingPortal.Core.Entities
{
    public class TrippingBayOwner : BaseEntity, IAggregateRoot
    {
        public Tripping Tripping { get; set; }
        public int TrippingId { get; set; }

        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
