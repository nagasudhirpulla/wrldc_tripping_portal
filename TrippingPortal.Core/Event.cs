﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TrippingPortal.Core
{
    /**
     * A Grid Event. 
     * Multiple trippings can be associated with a Grid Event.
     * Each event will have a single classification
     * Preliminary report - A single file to be uploaded by the utility.
     * Todo create documentation on constraints, upload time restrictions of utility preliminary report
     * Utility Final report - A single file to be uploaded by the utility.
     * RLDC Final report - A single file to be uploaded by the RLDC.
     * PCM discussion file - A single file to be uploaded by the RLDC.
     * Each event will have a set of multiple Event logs.
     * **/
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
