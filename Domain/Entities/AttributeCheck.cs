using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_AttributeCheckHeader")]
    public class AttributeCheck : BaseAuditable
    {
        public AttributeCheck()
        {
            this.AttributeCheckDetails = new List<AttributeCheckDetails>();
        }

        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public long? ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public string? BottleDateCode { get; set; }
        public string? PackSize { get; set; }
        public bool? IsWeightRange { get; set; } = false;
        public string? Note { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ProductMaster ProductMaster { get; set; }
        public virtual ProductionOrder ProductionOrder { get; set; }
        public virtual ICollection<AttributeCheckDetails> AttributeCheckDetails { get; set; }
    }
}
