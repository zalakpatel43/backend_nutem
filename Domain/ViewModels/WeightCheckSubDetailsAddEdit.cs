using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    
    public class WeightCheckSubDetailsAddEdit
    {
        public WeightCheckSubDetailsAddEdit()
        {

        }
        public long Id { get; set; }
        public long? DetailId { get; set; }
        public long? NozzleId { get; set; }
        public decimal? Weight { get; set; }
        public bool? IsActive { get; set; }
    }
}
