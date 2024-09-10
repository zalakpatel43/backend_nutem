using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LiquidPreparationAddEdit
    {
        public LiquidPreparationAddEdit()
        {
            this.liquidPreparationAdjustmentDetails = new List<LiquidPreparationAdjustmentDetailsAddEdit>();
            this.liquidPreparationChecklistDetails = new List<LiquidPreparationChecklistDetailsAddEdit>();
            this.liquidPreparationInstructionDetails = new List<LiquidPreparationInstructionDetailsAddEdit>();
            this.liquidPreparationSpecificationDetails = new List<LiquidPreparationSpecificationDetailsAddEdit>();
        }
        public long Id { get; set; }
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
        public string[] AnalysisDoneByList { get; set; }
        public DateTime? SampleReceivedTime { get; set; }
        public DateTime? SampleTestedTime { get; set; }
        public bool IsActive { get; set; }
        public string ShiftName { get; set; }
        public string ProductName { get; set; }

        public List<LiquidPreparationAdjustmentDetailsAddEdit> liquidPreparationAdjustmentDetails { get; set; }
        public List<LiquidPreparationChecklistDetailsAddEdit> liquidPreparationChecklistDetails { get; set; }
        public List<LiquidPreparationInstructionDetailsAddEdit> liquidPreparationInstructionDetails { get; set; }
        public List<LiquidPreparationSpecificationDetailsAddEdit> liquidPreparationSpecificationDetails { get; set; }

        public string StartDT
        {
            get
            {
                string formatDate = "";
                if (StartDateTime != null && StartDateTime != DateTime.MinValue)
                {
                    formatDate = StartDateTime.Value.ToString("dd-MMM-yyyy hh:MM tt");
                }
                return formatDate;
            }
        }

        public string EndDT
        {
            get
            {
                string formatDate = "";
                if (EndDateTime != null && EndDateTime != DateTime.MinValue)
                {
                    formatDate = EndDateTime.Value.ToString("dd-MMM-yyyy hh:MM tt");
                }
                return formatDate;
            }
        }
    }
}
