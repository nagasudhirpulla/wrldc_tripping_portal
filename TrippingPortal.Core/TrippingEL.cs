using System;

namespace TrippingPortal.Core
{
    public class TrippingEL
    {
        public int TrippingELId { get; set; }

        public Tripping Tripping { get; set; }
        public int TrippingId { get; set; }

        public string Filename { get; set; }

        public Utility UploadUtility { get; set; }
        public int UploadUtilityId { get; set; }

        public DateTime FileUploadTime { get; set; }
    }
}
