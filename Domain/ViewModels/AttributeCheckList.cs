using System;

namespace Domain.ViewModels
{
    public class AttributeCheckList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public long? ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public string BottleDateCode { get; set; }
        public string PackSize { get; set; }
        public bool? IsWeightRange { get; set; }
    }
}
