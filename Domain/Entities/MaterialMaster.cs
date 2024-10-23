using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaterialMaster : BaseAuditable
    {
        public string Code { get; set; }
        public string MaterialName { get; set; }
        public string PartCode { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<LiquidPreparationInstructionDetails> LiquidPreparationInstructionDetails { get; set; }
        public virtual ICollection<LiquidPreparationAdjustmentDetails> LiquidPreparationAdjustmentDetails { get; set; }
        public virtual ICollection<ProductInstructionDetails> ProductInstructionDetails { get; set; }
    }
}
