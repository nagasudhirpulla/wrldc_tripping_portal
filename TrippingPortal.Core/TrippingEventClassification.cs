using System.ComponentModel.DataAnnotations;

namespace TrippingPortal.Core
{
    /**
     * Name is unique
     * **/
    public class EventClassification
    {
        public int EventClassificationId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
