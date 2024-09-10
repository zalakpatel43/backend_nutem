using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class DowntimeTrackingList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? ProductionDateTime { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public long? ProductLineId { get; set; }
        public string ProductLineName { get; set; }

        public bool IsActive { get; set; }
        public long? SAPProductionOrderId { get; set; }
    }
}
