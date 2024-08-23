using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class WeightCheckDetailsAddEdit
    {
        public WeightCheckDetailsAddEdit()
        {
            this.WeightCheckSubDetails = new List<WeightCheckSubDetailsAddEdit>();
        }
        public long Id { get; set; }
        public long? HeaderId { get; set; }
        public DateTime? TDateTime { get; set; }
        public decimal? AvgWeight { get; set; }
        public string DoneByUserIds { get; set; }
        public string[] DoneByUserIdList { get; set; }
        public string DoneByUserNames { get; set; }
        public bool? IsActive { get; set; }

        public List<WeightCheckSubDetailsAddEdit> WeightCheckSubDetails { get; set; }
    }
}
