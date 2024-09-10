using System;

namespace Domain.ViewModels
{
    public class PostCheckList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? EndDateTime { get; set; } // Replaces StartDateTime with EndDateTime
        public long ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; } // Assuming you want to include product name
        public long? ShiftId { get; set; }
        public string ShiftName { get; set; } // Assuming you want to include shift name
        public long? FillingLine { get; set; }
        public string FillingLineNumber { get; set; }
        public string FillerUserIds { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }

        public string EndDateTimeFormatted
        {
            get
            {
                return EndDateTime.HasValue ? EndDateTime.Value.ToString("dd-MMM-yyyy hh:mm tt") : "N/A";
            }
        }
    }
}
