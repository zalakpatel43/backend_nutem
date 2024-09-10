using Skyward.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_PostCheckList")]
    public class PostCheckListEntity : BaseAuditable
    {
        public PostCheckListEntity()
        {
            this.PostCheckListDetails = new List<PostCheckListDetailEntity>();
            this.PrePostQuestionEntity = new List<PrePostQuestionEntity>();
        }

        public string Code { get; set; }
        public DateTime? EndDateTime { get; set; } // Replaced StartDateTime with EndDateTime
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
        public virtual MastersEntity Masters { get; set; }
        public virtual ICollection<PostCheckListDetailEntity> PostCheckListDetails { get; set; }
        public virtual ICollection<PrePostQuestionEntity> PrePostQuestionEntity { get; set; }
    }
}
