using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Skyward.Model;

namespace Domain.Entities
{
    [Table("adm_DowntimeTracking")]
    public class DowntimeTracking : BaseAuditable
    {
        public DowntimeTracking()
        {
            this.DownTimeTrackingDetails = new List<DowntimeTrackingDetails>();
        }

        public string Code { get; set; }
        public DateTime ProductionDateTime { get; set; }
        public long ProductId { get; set; }
        public long ProductLineId { get; set; }
        public bool IsActive { get; set; }
        public long? SAPProductionOrderId { get; set; }

        public virtual ProductionOrder ProductionOrder { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual MastersEntity Masters { get; set; }
        // public virtual ProductionLineMaster ProductionLineMaster { get; set; } // Uncomment if needed

        public virtual ICollection<DowntimeTrackingDetails> DownTimeTrackingDetails { get; set; }
        public virtual ICollection<CauseMaster> CauseMaster { get; set; }
        //public virtual ICollection<MastersEntity> MastersEntity { get; set; }

    }
}
