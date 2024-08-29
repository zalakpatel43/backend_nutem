using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_CauseMaster")]
    public class CauseMaster : BaseAuditable
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string CauseName { get; set; }
        public bool? IsActive { get; set; }

        // Add navigation properties if needed
        // public virtual ICollection<RelatedEntity> RelatedEntities { get; set; }
    }
}
