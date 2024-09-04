using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_PostCheckListDetails")]
    public class PostCheckListDetailEntity : BaseAuditable
    {
        public long HeaderId { get; set; }
        public long QuestionId { get; set; }
        public int Answer { get; set; }
        public string Reason { get; set; }
        public bool IsActive { get; set; }
        public long PostCheckListId { get; set; }

        public virtual PrePostQuestionEntity PrePostQuestion { get; set; }
        public virtual PostCheckListEntity PostCheckList { get; set; }
    }
}
