using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LiquidPreparationSpecificationDetails : BaseAuditable
    {
        public LiquidPreparationSpecificationDetails()
        {

        }

        public long? LiquidPreparationId { get; set; }
        public long? SpecificationLimitId { get; set; }
        public string Test1 { get; set; }
        public string Test2 { get; set; }
        public DateTime? TestingDateTime { get; set; }
        public string AnalysisDoneByIds { get; set; }
        public DateTime? SampleReceivedTime { get; set; }
        public DateTime? SampleTestedTime { get; set; }
        public bool IsActive { get; set; }
        public virtual LiquidPreparation LiquidPreparation { get; set; }
        public virtual QCTSpecificationMaster QCTSpecificationMaster { get; set; }
    }
}
