using System;
using System.ComponentModel.DataAnnotations;

namespace TrippingPortal.Core
{
    /**
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
