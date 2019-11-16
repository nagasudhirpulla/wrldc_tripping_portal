using System.ComponentModel.DataAnnotations;
using TrippingPortal.Core.Interfaces;

namespace TrippingPortal.Core.Entities
{
    /**
     * Each event will have a single classification
     * Name is unique
     * **/
    public class EventClassification : BaseEntity, IAggregateRoot
    {
        [Required]
        public string Name { get; set; }
    }
}
