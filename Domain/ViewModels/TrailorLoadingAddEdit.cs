using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class TrailerLoadingAddEdit
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? TLDateTime { get; set; }
        public string DoorNo { get; set; }
        public string TrailerNo { get; set; }
        public string BOLNo { get; set; }
        public long? SupervisedBy { get; set; }
        public DateTime? SupervisedOn { get; set; }
        public bool? IsActive { get; set; }

        public List<TrailerLoadingDetailsAddEdit> TrailerLoadingDetails { get; set; } = new List<TrailerLoadingDetailsAddEdit>();

        public string TLDate
        {
            get
            {
                string formatDate = "";
                if (TLDateTime != null && TLDateTime != DateTime.MinValue)
                {
                    formatDate = TLDateTime.Value.ToString("dd-MMM-yyyy hh:mm tt");
                }
                return formatDate;
            }
        }

        public string SupervisedDT
        {
            get
            {
                string formatDate = "";
                if (SupervisedOn != null && SupervisedOn != DateTime.MinValue)
                {
                    formatDate = SupervisedOn.Value.ToString("dd-MMM-yyyy hh:mm tt");
                }
                return formatDate;
            }
        }
    }
}
