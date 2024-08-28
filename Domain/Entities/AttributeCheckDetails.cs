using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_AttributeCheckDetails")]
    public class AttributeCheckDetails : BaseAuditable
    {
        public long? HeaderId { get; set; }
        public DateTime? TDateTime { get; set; }
        public bool IsGoodCondition { get; set; }
        public string? CapTorque { get; set; }
        public string? EmptyBottleWeight { get; set; }
        public string? LotNoOfLiquid { get; set; }
        public bool IsCorrect { get; set; }
        public int LeakTest { get; set; }
        public string? DoneByUserIds { get; set; }
        public string? DoneByUserNames { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual AttributeCheck AttributeCheck { get; set; }
    }
}
