using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductInstructionDetails : BaseAuditable
    {
        public ProductInstructionDetails()
        {
        }

        public long? ProductId { get; set; }
        public string Instruction { get; set; }
        public decimal? Weight { get; set; }
        public bool IsActive { get; set; }

        public virtual ProductMaster ProductMaster { get; set; }
        public virtual ICollection<LiquidPreparationInstructionDetails> LiquidPreparationInstructionDetails { get; set; }
    }
}
