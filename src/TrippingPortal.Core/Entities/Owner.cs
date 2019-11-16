using System.ComponentModel.DataAnnotations;
using TrippingPortal.Core.Interfaces;

namespace TrippingPortal.Core.Entities
{
    /**
     * Owner means Grid Element Owner
     * Name is unique
     * **/
    public class Owner : BaseEntity, IAggregateRoot
    {
        [Required]
        public string Name { get; set; }
    }
}
