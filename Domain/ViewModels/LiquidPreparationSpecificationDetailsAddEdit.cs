using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LiquidPreparationSpecificationDetailsAddEdit
    {
        public LiquidPreparationSpecificationDetailsAddEdit()
        {
        }
        public long Id { get; set; }
        public long? LiquidPreparationId { get; set; }
        public long? SpecificationLimitId { get; set; }
        public string Test1 { get; set; }
        public string Test2 { get; set; }
        public DateTime? TestingDateTime { get; set; }
        public string AnalysisDoneByIds { get; set; }
        public string[] AnalysisDoneByList { get; set; }
        public DateTime? SampleReceivedTime { get; set; }
        public DateTime? SampleTestedTime { get; set; }
        public bool IsActive { get; set; }

        public string SpecificationLimit { get; set; }
    }
}
