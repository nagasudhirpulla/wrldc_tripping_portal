using System;

namespace TrippingPortal.Core
{
    /**
     * An event log (EL) file for a tripping
     * A tripping can have multiple event logs
     * **/
    public class TrippingEL
    {
        public int TrippingELId { get; set; }

        public Tripping Tripping { get; set; }
        public int TrippingId { get; set; }

        public string Filename { get; set; }

        public Utility UploadUtility { get; set; }
        public int UploadUtilityId { get; set; }

        public DateTime FileUploadTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
