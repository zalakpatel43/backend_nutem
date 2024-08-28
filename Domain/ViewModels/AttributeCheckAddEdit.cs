using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class AttributeCheckAddEdit
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public long? ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public string BottleDateCode { get; set; }
        public string PackSize { get; set; }
        public bool? IsWeightRange { get; set; } = false;
        public string Note { get; set; }
        public bool? IsActive { get; set; }

        public List<AttributeCheckDetailsAddEdit> AttributeCheckDetails { get; set; } = new List<AttributeCheckDetailsAddEdit>();

        public string StartDT
        {
            get
            {
                string formatDate = "";
                if (StartDateTime != null && StartDateTime != DateTime.MinValue)
                {
                    formatDate = StartDateTime.Value.ToString("dd-MMM-yyyy hh:mm tt");
                }
                return formatDate;
            }
        }

        public string EndDT
        {
            get
            {
                string formatDate = "";
                if (EndDateTime != null && EndDateTime != DateTime.MinValue)
                {
                    formatDate = EndDateTime.Value.ToString("dd-MMM-yyyy hh:mm tt");
                }
                return formatDate;
            }
        }
    }
}
