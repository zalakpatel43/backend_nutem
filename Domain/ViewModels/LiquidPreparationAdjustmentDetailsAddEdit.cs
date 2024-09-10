using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LiquidPreparationAdjustmentDetailsAddEdit
    {
        public LiquidPreparationAdjustmentDetailsAddEdit()
        {
        }
        public long Id { get; set; }
        public long? LiquidPreparationId { get; set; }
        public long? MaterialId { get; set; }
        public long? LiquidPreparationInstructionId { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal? Total { get; set; }
        public bool IsActive { get; set; }
        public int? IsEmpty { get; set; } = 0;

        public string Material { get; set; }
    }
}
