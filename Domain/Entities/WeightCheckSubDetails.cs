using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_WeightCheckSubDetails")]
    public class WeightCheckSubDetails : BaseAuditable
    {
        public WeightCheckSubDetails()
        {

        }

        public long? DetailId { get; set; }
        public long? NozzleId { get; set; }
        public decimal? Weight { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual WeightCheckDetails WeightCheckDetails { get; set; }
        public virtual NozzelMaster NozzelMaster { get; set; }
    }
}
