using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class WeightCheckAddEdit
    {
       // public WeightCheckAddEdit()
       // {
            //this.WeightCheckDetails = new List<WeightCheckDetailsAddEdit>();
       // }
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public long? SAPProductionOrderId { get; set; }
        public long? ProductId { get; set; }
      //  public string ProductName { get; set; }
        public long? ShiftId { get; set; }
        public string BottleDateCode { get; set; }
        public string PackSize { get; set; }
        public string? TargetWeight { get; set; }
        public decimal? MinWeightRange { get; set; }
        public decimal? MaxWeightRange { get; set; }
        public long? QAUserId { get; set; }
        public string Note { get; set; }
        public bool? IsActive { get; set; }
        //  public string ShiftName { get; set; }

        public List<WeightCheckDetailsAddEdit> WeightCheckDetails { get; set; } = new List<WeightCheckDetailsAddEdit>();


        public string StartDT
        {
            get
            {
                string formatDate = "";
                if (StartDateTime != null && StartDateTime != DateTime.MinValue)
                {
                    formatDate = StartDateTime.Value.ToString("dd-MMM-yyyy hh:MM tt");
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
                    formatDate = EndDateTime.Value.ToString("dd-MMM-yyyy hh:MM tt");
                }
                return formatDate;
            }
        }
    }
}
