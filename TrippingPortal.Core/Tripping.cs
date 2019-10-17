using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrippingPortal.Core
{
    /**
     * Tripping means an event of an Element tripping
     * Tripping Element Owners, Bay Owners todo
     * **/
    public class Tripping
    {
        public int TrippingId { get; set; }

        public Event Event { get; set; }
        public int EventId { get; set; }

        public int ForeignId { get; set; }
        [Required]
        public string ElementName { get; set; }
        [Required]
        public string ElementType { get; set; }

        public List<Owner> ElementOwners { get; set; }
        public List<Owner> BayOwners { get; set; }
        public List<Utility> ReportUploadUtilities { get; set; }
        public List<Utility> OtherEndReportUploadUtilities { get; set; }

        [Required]
        public DateTime OutageTime { get; set; }

        public DateTime RevivalTime { get; set; }

        [Required]
        public string Reason { get; set; }
        [Required]
        public string Remarks { get; set; }
        public string OutageType { get; set; }
    }
}
