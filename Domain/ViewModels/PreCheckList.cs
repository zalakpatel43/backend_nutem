using System;

namespace Domain.ViewModels
{
    public class PreCheckList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public long ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; } // Assuming you want to include product name
        public long? ShiftId { get; set; }
        public string ShiftName { get; set; } // Assuming you want to include shift name
        public long? FillingLine { get; set; }
        public string FillerUserIds { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }

        public string StartDateTimeFormatted
        {
            get
            {
                return StartDateTime.HasValue ? StartDateTime.Value.ToString("dd-MMM-yyyy hh:mm tt") : "N/A";
            }
        }
    }
}
