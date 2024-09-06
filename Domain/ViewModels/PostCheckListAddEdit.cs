using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class PostCheckListAddEdit
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? EndDateTime { get; set; } // Replaced StartDateTime with EndDateTime
        public long ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public long? ShiftId { get; set; }
        public long? FillingLine { get; set; }
        public string FillerUserIds { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; } = true;
        public long PrePostQuestionId { get; set; }

        public List<PostCheckListDetailAddEdit> PostCheckListDetails { get; set; } = new List<PostCheckListDetailAddEdit>();

        public string EndDateTimeFormatted
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
