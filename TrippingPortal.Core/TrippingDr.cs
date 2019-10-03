using System;

namespace TrippingPortal.Core
{
    public class TrippingDr
    {
        public int TrippingDrId { get; set; }
        public string Filename { get; set; }

        public Utility UploadUtility { get; set; }
        public int UploadUtilityId { get; set; }

        public DateTime FileUploadTime { get; set; }
    }
}
