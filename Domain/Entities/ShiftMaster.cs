using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_ShiftMaster")]
    public class ShiftMaster : BaseAuditable
    {
        public long Id { get; set; }
        public string ShiftName { get; set; }
        public string ShiftCode { get; set; }
        public bool? IsActive { get; set; } 

        //public virtual ICollection<PreCheckListEntity> PreCheckList { get; set; }
        //public virtual ICollection<PostCheckListEntity> PostCheckList { get; set; }
        public virtual ICollection<WeightCheck> WeightCheck { get; set; }
        //public virtual ICollection<LiquidPreparationEntity> LiquidPreparationEntities { get; set; }
    }
}
