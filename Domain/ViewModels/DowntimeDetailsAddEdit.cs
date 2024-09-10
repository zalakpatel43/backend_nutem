using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class DowntimeTrackingDetailsAddEdit
    {
        public long Id { get; set; }

        public long? HeaderId { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string Durations { get; set; }
        public long? CauseId { get; set; }
        public long? ShiftId { get; set; }
        public string ActionTaken { get; set; }

        public string DoneByUserIds { get; set; }
    
        public string DoneByUserNames { get; set; }
        public bool? IsActive { get; set; }

        // List initialization is not needed here since it's a single detail item
    }
}
