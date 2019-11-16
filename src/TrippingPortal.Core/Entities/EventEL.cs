using System;
using System.ComponentModel.DataAnnotations;
using TrippingPortal.Core.Interfaces;

namespace TrippingPortal.Core.Entities
{
    /**
     * An Event log (EL) file for an event
     * A single event can have multiple event logs
     * **/
    public class EventEL : BaseEntity, IAggregateRoot
    {
        public Event Event { get; set; }
        public int EventId { get; set; }

        public string Filename { get; set; }

        public Utility UploadUtility { get; set; }
        public string UploadUtilityId { get; set; }

        public Utility UploadedBy { get; set; }
        public string UploadedById { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
