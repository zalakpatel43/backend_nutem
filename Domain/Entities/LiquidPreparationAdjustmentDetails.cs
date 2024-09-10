using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LiquidPreparationAdjustmentDetails : BaseAuditable
    {
        public LiquidPreparationAdjustmentDetails()
        {

        }

        public long? LiquidPreparationId { get; set; }
        public long? MaterialId { get; set; }
        public long? LiquidPreparationInstructionId { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal? Total { get; set; }
        public bool IsActive { get; set; }
        public virtual LiquidPreparation LiquidPreparation { get; set; }
        public virtual MaterialMaster MaterialMaster { get; set; }
        public virtual LiquidPreparationInstructionDetails LiquidPreparationInstructionDetails { get; set; }
    }
}
