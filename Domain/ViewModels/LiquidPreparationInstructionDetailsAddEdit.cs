using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LiquidPreparationInstructionDetailsAddEdit
    {
        public LiquidPreparationInstructionDetailsAddEdit()
        {
        }
        public long Id { get; set; }
        public long? LiquidPreparationId { get; set; }
        public long? InstructionId { get; set; }
        public long? MaterialId { get; set; }
        public string LotNumber { get; set; }
        public decimal? Weight { get; set; }
        public decimal? WeightAdded { get; set; }
        public string DoneByIds { get; set; }
        public string[] DoneByList { get; set; }
        public DateTime? AddedTime { get; set; }
        public string CurrentTime { get; set; }
        public bool IsActive { get; set; }

        public string Instruction { get; set; }
        public string Material { get; set; }
    }
}
