using System;

namespace TrippingPortal.Core
{
    /**
     * Disturbance Recorder (DR) file for a tripping.
     * A tripping can have multiple DRs
     * In case of line, we have End1, End2 DRs
     * In case of ICT, we have HV, LV DRs
     * **/
    public class TrippingDr
    {
        public int TrippingDrId { get; set; }
        public string Filename { get; set; }

        public Utility UploadUtility { get; set; }
        public int UploadUtilityId { get; set; }

        public DateTime FileUploadTime { get; set; }
    }
}
