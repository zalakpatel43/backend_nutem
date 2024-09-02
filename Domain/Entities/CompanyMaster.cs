using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_CompanyMaster")]
    public class CompanyMaster : BaseAuditable
    {
        public string Code { get; set; }
        public string CompanyName { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<TrailerInspection> TrailerInspection { get; set; }
    }
}
