using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StartEndBatchChecklist : BaseAuditable
    {
        public string Type { get; set; }
        public string Question { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<LiquidPreparationChecklistDetails> LiquidPreparationChecklistDetails { get; set; }
    }
}
