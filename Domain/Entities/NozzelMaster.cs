using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_NozzelMaster")]
    public class NozzelMaster : BaseAuditable
    {
        public long Id { get; set; }
        public string NozzelCode { get; set; }
        public string? NozzelName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<WeightCheckSubDetails> WeightCheckSubDetails { get; set; }
    }
}
