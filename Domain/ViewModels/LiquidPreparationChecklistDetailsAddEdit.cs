using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LiquidPreparationChecklistDetailsAddEdit
    {
        public LiquidPreparationChecklistDetailsAddEdit()
        {
        }
        public long Id { get; set; }
        public long? LiquidPreparationId { get; set; }
        public string Type { get; set; }
        public long? QuestionId { get; set; }
        public string Answer { get; set; }
        public string TankNo { get; set; }
        public bool IsActive { get; set; }
        public string Question { get; set; }
        public long? TankId { get; set; }
        public string Reason { get; set; }
    }
}
