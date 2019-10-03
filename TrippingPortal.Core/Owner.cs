using System.ComponentModel.DataAnnotations;

namespace TrippingPortal.Core
{
    /**
     * Name is unique
     * **/
    public class Owner
    {
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
