namespace TrippingPortal.Core
{
    public class TrippingElementOwner
    {
        public int TrippingElementOwnerId { get; set; }

        public Tripping Tripping { get; set; }
        public int TrippingId { get; set; }

        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
