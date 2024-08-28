using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_WeightCheckHeader")]
    public class WeightCheck : BaseAuditable
    {
        //public WeightCheck()
        //{
        //    this.WeightCheckDetails = new List<WeightCheckDetails>();
        //}

        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public long? SAPProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public long? ShiftId { get; set; }
        public string? BottleDateCode { get; set; }
        public string? PackSize { get; set; }
        public string? TargetWeight { get; set; }
        public decimal? MinWeightRange { get; set; }
        public decimal? MaxWeightRange { get; set; }
        public long? QAUserId { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual ProductionOrder ProductionOrder { get; set; }
        public virtual ShiftMaster ShiftMaster { get; set; }
        public virtual ICollection<WeightCheckDetails> WeightCheckDetails { get; set; }


    }
}
