namespace TrippingPortal.Core
{
    /**
     * Many-Many relation between Utility and Owner
     * **/
    public class UtilityOwner
    {
        public int UtilityOwnerId { get; set; }
        public Utility Utility { get; set; }
        public string UtilityId { get; set; }
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
