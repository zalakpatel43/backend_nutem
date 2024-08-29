using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Domain.Entities
{
    [Table("adm_DowntimeTrackingDetails")]
    public class DowntimeTrackingDetails : BaseAuditable
    {
        public DowntimeTrackingDetails()
        {
            // Initialize any collections if needed
            // e.g., this.SomeCollection = new List<SomeEntity>();
        }

        public long HeaderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Durations { get; set; }
        public long CauseId { get; set; }
        public string ActionTaken { get; set; }
        public long ActionTakenId { get; set; }
        public bool IsActive { get; set; }
        public virtual DowntimeTracking DowntimeTracking { get; set; }

    }
}
