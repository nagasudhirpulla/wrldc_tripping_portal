﻿using System;

namespace TrippingPortal.Core
{
    public class EventEL
    {
        public int EventELId { get; set; }

        public Event Event { get; set; }
        public int EventId { get; set; }

        public string Filename { get; set; }

        public Utility UploadUtility { get; set; }
        public int UploadUtilityId { get; set; }

        public Utility UploadedBy { get; set; }
        public int UploadedById { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
