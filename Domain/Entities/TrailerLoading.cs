using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_TrailerLoadingHeader")]
    public class TrailerLoading : BaseAuditable
    {
        public TrailerLoading()
        {
            this.TrailerLoadingDetails = new List<TrailerLoadingDetails>();
        }

        public string Code { get; set; }
        public DateTime? TLDateTime { get; set; }
        public string DoorNo { get; set; }
        public string TrailerNo { get; set; }
        public string BOLNo { get; set; }
        public long? SupervisedBy { get; set; }
        public DateTime? SupervisedOn { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<TrailerLoadingDetails> TrailerLoadingDetails { get; set; }
        public virtual User HeadUser { get; set; }

        public virtual ProductionOrder ProductionOrder { get; set; }
    }
}
