using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TankMaster : BaseAuditable
    {
        public string TankCode { get; set; }
        public string TankName { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<LiquidPreparation> LiquidPreparation { get; set; }
        public virtual ICollection<LiquidPreparationChecklistDetails> LiquidPreparationChecklistDetails { get; set; }
    }
}
