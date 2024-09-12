using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LiquidPreparationList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public long? ShiftId { get; set; }
        public string ShiftName { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
