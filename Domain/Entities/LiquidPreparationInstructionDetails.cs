using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LiquidPreparationInstructionDetails : BaseAuditable
    {
        public LiquidPreparationInstructionDetails()
        {

        }

        public long? LiquidPreparationId { get; set; }
        public long? InstructionId { get; set; }
        public long? MaterialId { get; set; }
        public string LotNumber { get; set; }
        public decimal? Weight { get; set; }
        public decimal? WeightAdded { get; set; }
        public string DoneByIds { get; set; }
        public DateTime? AddedTime { get; set; }
        public bool IsActive { get; set; }
        public virtual LiquidPreparation LiquidPreparation { get; set; }
        public virtual ProductInstructionDetails ProductInstructionDetails { get; set; }
        public virtual MaterialMaster MaterialMaster { get; set; }
        public virtual ICollection<LiquidPreparationAdjustmentDetails> LiquidPreparationAdjustmentDetails { get; set; }
    }
}
