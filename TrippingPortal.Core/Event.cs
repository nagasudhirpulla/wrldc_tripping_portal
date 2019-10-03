using System;
using System.ComponentModel.DataAnnotations;

namespace TrippingPortal.Core
{
    public class Event
    {
        public int TrippingEventId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }

        public EventClassification EventClassification { get; set; }
        public int EventClassificationId { get; set; }

        public string PreliminaryReportFilePath { get; set; }
        public string RldcFinalReportFilePath { get; set; }
        public string UtilityFinalReportFilePath { get; set; }
        public string PcmDiscussionReportFilePath { get; set; }
        public DateTime UtilityFinalReportUploadTime { get; set; }

        public Utility FinalReportUploadUtility { get; set; }
        public int FinalReportUploadUtilityId { get; set; }
    }
}
