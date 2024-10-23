using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    [Table("adm_LaborVarianceDetails")]
    public class LaborVarianceDetails : BaseAuditable
    {
        public long? HeaderId { get; set; }
        public long? SAPProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? LateStartReason { get; set; }
        public decimal? ChangeOverTime { get; set; }
        public long? ActualBottleProduced { get; set; }
        public decimal? TotalRunTImeMins { get; set; }
        public string? ShiftComments { get; set; }
        public decimal? DownTimeMins { get; set; }
        public string? DownTImeComments { get; set; }
        public long? HC { get; set; }
        public decimal? CaseAttainment { get; set; }
        public decimal? CaseTarget { get; set; }
        public decimal? Percentage { get; set; }
        public long? BottleTarget { get; set; }
        public string? ShiftIndex { get; set; }
        public string? Criteria { get; set; }
        public long? MissingFGItems { get; set; }
        public decimal? NonProductionTime { get; set; }
        public string? AdditionalComments { get; set; }
        public decimal? TimePerPerson { get; set; }
        public decimal? TotalMins { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ProductionOrder ProductionOrder { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual LaborVariance LaborVariance { get; set; }
    }
}
