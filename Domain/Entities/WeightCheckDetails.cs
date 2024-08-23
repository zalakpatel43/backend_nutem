using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("adm_WeightCheckDetails")]
    public class WeightCheckDetails : BaseAuditable
    {
        public WeightCheckDetails()
        {
            this.WeightCheckSubDetails = new List<WeightCheckSubDetails>();
        }

        public long? HeaderId { get; set; }
        public DateTime? TDateTime { get; set; }
        public decimal? AvgWeight { get; set; }
        public string? DoneByUserIds { get; set; }
        public string? DoneByUserNames { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual WeightCheck WeightCheck { get; set; }
        public virtual ICollection<WeightCheckSubDetails> WeightCheckSubDetails { get; set; }
    }
}
