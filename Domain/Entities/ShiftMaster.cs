﻿using System;
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

        public virtual ICollection<PreCheckListEntity> PreCheckListEntity { get; set; }
        public virtual ICollection<PostCheckListEntity> PostCheckListEntity { get; set; }
        public virtual ICollection<WeightCheck> WeightCheck { get; set; }
        public virtual ICollection<LiquidPreparation> LiquidPreparation { get; set; }
        public virtual ICollection<LaborVariance> LaborVariance { get; set; }
    }
}
