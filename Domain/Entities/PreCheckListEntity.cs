using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_PreCheckList")]
    public class PreCheckListEntity : BaseAuditable
    {
        public PreCheckListEntity()
        {
            this.PreCheckListDetails = new List<PreCheckListDetailEntity>();

            this.PrePostQuestionEntity = new List<PrePostQuestionEntity>();
        }

        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public long ProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public long? ShiftId { get; set; }
        public long? FillingLine { get; set; }
        public string FillerUserIds { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public long PrePostQuestionId { get; set; }

        public PrePostQuestionEntity PrePostQuestion { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual ShiftMaster ShiftMaster { get; set; }
        public virtual ICollection<PreCheckListDetailEntity> PreCheckListDetails { get; set; }
        public virtual ICollection<PrePostQuestionEntity> PrePostQuestionEntity { get; set; }
    }
}
