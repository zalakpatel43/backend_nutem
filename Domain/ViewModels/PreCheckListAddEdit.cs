using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class PreCheckListAddEdit
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public long ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public long? ShiftId { get; set; }
        public long? FillingLine { get; set; }
        public string FillerUserIds { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; } = true;
        public long PrePostQuestionId { get; set; }

        public List<PreCheckListDetailAddEdit> PreCheckListDetails { get; set; } = new List<PreCheckListDetailAddEdit>();

        public string StartDateTimeFormatted
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
    }
}
