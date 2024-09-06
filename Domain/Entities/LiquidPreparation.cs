using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LiquidPreparation : BaseAuditable
    {
        //public LiquidPreparation()
        //{
        //    this.LiquidPreparationChecklistDetailsEntities = new List<LiquidPreparationChecklistDetailsEntity>();
        //    this.LiquidPreparationInstructionDetailsEntities = new List<LiquidPreparationInstructionDetailsEntity>();
        //    this.LiquidPreparationSpecificationDetailsEntities = new List<LiquidPreparationSpecificationDetailsEntity>();
        //    this.LiquidPreparationAdjustmentDetailsEntities = new List<LiquidPreparationAdjustmentDetailsEntity>();
        //}

        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public long? SAPProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public long? ShiftId { get; set; }
        public string BatchLotNumber { get; set; }
        public long? TankId { get; set; }
        public long? CompounderUserId { get; set; }
        public string StandardBatchWeight { get; set; }
        public DateTime? TestingDateTime { get; set; }
        public string AnalysisDoneByIds { get; set; }
        public DateTime? SampleReceivedTime { get; set; }
        public DateTime? SampleTestedTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ShiftMaster ShiftMaster { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual TankMaster TankMaster { get; set; }
        public virtual ProductionOrder ProductionOrder { get; set; }
        public virtual ICollection<LiquidPreparationChecklistDetails> LiquidPreparationChecklistDetails { get; set; }
        public virtual ICollection<LiquidPreparationInstructionDetails> LiquidPreparationInstructionDetails { get; set; }
        public virtual ICollection<LiquidPreparationSpecificationDetails> LiquidPreparationSpecificationDetails { get; set; }
        public virtual ICollection<LiquidPreparationAdjustmentDetails> LiquidPreparationAdjustmentDetails { get; set; }
    }
}
