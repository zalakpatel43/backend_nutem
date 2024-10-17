using Skyward.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_LaborVarianceHeader")]
    public class LaborVariance : BaseAuditable
    {
        public string Code { get; set; }
        public DateTime? DateTime { get; set; }
        public long? ShiftId { get; set; }
        public long? ProductLineId { get; set; }
        public long? Employees { get; set; }
        public long? TempEmployee { get; set; }
        public long? TotalEmployee { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ShiftMaster ShiftMaster { get; set; }
        public virtual MastersEntity Masters { get; set; }
        public virtual ICollection<LaborVarianceDetails> LaborVarianceDetails { get; set; }


    }
}
