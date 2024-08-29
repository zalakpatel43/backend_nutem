using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class AttributeCheckAddEdit
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? ACDate { get; set; } // Changed from StartDateTime and EndDateTime to a single ACDate
        public long? ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public string BottleDateCode { get; set; }
        public string PackSize { get; set; }
        public bool? IsWeightRange { get; set; } = false;
        public string Note { get; set; }
        public bool? IsActive { get; set; }

        public List<AttributeCheckDetailsAddEdit> AttributeCheckDetails { get; set; } = new List<AttributeCheckDetailsAddEdit>();

        public string ACDateFormatted
        {
            get
            {
                string formatDate = "";
                if (ACDate != null && ACDate != DateTime.MinValue)
                {
                    formatDate = ACDate.Value.ToString("dd-MMM-yyyy hh:mm tt");
                }
                return formatDate;
            }
        }
    }
}
