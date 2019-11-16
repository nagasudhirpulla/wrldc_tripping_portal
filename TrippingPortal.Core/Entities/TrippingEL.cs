using System;
using TrippingPortal.Core.Interfaces;

namespace TrippingPortal.Core.Entities
{
    /**
     * An event log (EL) file for a tripping
     * A tripping can have multiple event logs
     * **/
    public class TrippingEL : BaseEntity, IAggregateRoot
    {
        public Tripping Tripping { get; set; }
        public int TrippingId { get; set; }

        public string Filename { get; set; }

        public Utility UploadUtility { get; set; }
        public string UploadUtilityId { get; set; }

        public DateTime FileUploadTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
