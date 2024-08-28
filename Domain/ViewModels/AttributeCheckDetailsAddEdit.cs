using System;

namespace Domain.ViewModels
{
    public class AttributeCheckDetailsAddEdit
    {
        public long Id { get; set; }
        public long? HeaderId { get; set; }
        public DateTime? TDateTime { get; set; }
        public bool IsGoodCondition { get; set; }
        public string CapTorque { get; set; }
        public string EmptyBottleWeight { get; set; }
        public string LotNoOfLiquid { get; set; }
        public bool IsCorrect { get; set; }
        public int LeakTest { get; set; }
        public string DoneByUserIds { get; set; }
        public long[] DoneByUserIdList { get; set; }
        public string DoneByUserNames { get; set; }
        public bool? IsActive { get; set; }
    }
}
