using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LaborVarianceAddEdit
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? DateTime { get; set; }
        public long? ShiftId { get; set; }
        public long? ProductLineId { get; set; }
        public long? Employees { get; set; }
        public long? TempEmployee { get; set; }
        public long? TotalEmployee { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; } = true;

        public List<LaborVarianceDetailsAddEdit> LaborVarianceDetails { get; set; } = new List<LaborVarianceDetailsAddEdit>();

        //public string StartDT
        //{
        //    get
        //    {
        //        string formatDate = "";
        //        if (StartDateTime != null && StartDateTime != DateTime.MinValue)
        //        {
        //            formatDate = StartDateTime.Value.ToString("dd-MMM-yyyy hh:MM tt");
        //        }
        //        return formatDate;
        //    }
        //}

    }
}
