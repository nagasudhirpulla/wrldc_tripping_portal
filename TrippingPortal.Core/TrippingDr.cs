using System;

namespace TrippingPortal.Core
{
    /**
     * Disturbance Recorder (DR) file for a tripping.
     * A tripping can have multiple DRs
     * In case of line, we have End1, End2 DRs
     * In case of ICT, we have HV, LV DRs
     * **/
    public class TrippingDR
    {
        public int TrippingDRId { get; set; }

        public Tripping Tripping { get; set; }
        public int TrippingId { get; set; }

        public bool IsOtherEndOrLV { get; set; }
        public string Filename { get; set; }

        public Utility UploadUtility { get; set; }
        public string UploadUtilityId { get; set; }

        public DateTime FileUploadTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
