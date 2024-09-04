using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_PrePostQuestion")]
    public class PrePostQuestionEntity : BaseAuditable
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Type { get; set; }  // 1 for Pre-check, 2 for Post-check
        public string Question { get; set; }
        public bool? IsActive { get; set; }

        // Define relationships to the detail entities if needed
        public virtual ICollection<PreCheckListEntity> PreCheckList { get; set; }
        public virtual ICollection<PostCheckListEntity> PostCheckListDetails { get; set; }
        //public virtual icollection<postchecklistdetail> postchecklistdetails { get; set; }
    }
}
