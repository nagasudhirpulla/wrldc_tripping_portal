namespace TrippingPortal.Core
{
    public class TrippingBayOwner
    {
        public int TrippingBayOwnerId { get; set; }

        public Tripping Tripping { get; set; }
        public int TrippingId { get; set; }

        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
