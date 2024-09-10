using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LiquidPreparationChecklistDetails : BaseAuditable
    {
        //public LiquidPreparationChecklistDetails()
        //{

        //}

        public long? LiquidPreparationId { get; set; }
        public string Type { get; set; }
        public long? QuestionId { get; set; }
        public string Answer { get; set; }
        public string TankNo { get; set; }
        public long? TankId { get; set; }
        public bool IsActive { get; set; }
        public string Reason { get; set; }
        public virtual TankMaster TankMaster { get; set; }
        public virtual LiquidPreparation LiquidPreparation { get; set; }
        public virtual StartEndBatchChecklist StartEndBatchChecklist { get; set; }
    }
}
