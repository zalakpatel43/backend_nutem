using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LaborVarianceList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? DateTime { get; set; }
        public long? ProductLineId { get; set; }
        public string ProductLineName { get; set; }
        public long? ShiftId { get; set; }
        public string ShiftName { get; set; }
        public long? TotalEmployee { get; set; }
    }
}
