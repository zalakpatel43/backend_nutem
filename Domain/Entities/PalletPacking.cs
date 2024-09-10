using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_PalletPackingHeader")]
    public class PalletPacking : BaseAuditable
    {
        public string Code { get; set; }
        public DateTime? PackingDateTime { get; set; }
        public long? SAPProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public decimal? FinishedCasesOnIncompletePalletAtStart { get; set; }
        public decimal? FinishedCasesOnIncompletePalletAtEnd { get; set; }
        public decimal? TotalCasesProduced { get; set; }
        public long? SupervisedBy { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual User HeadUser { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
        public virtual ProductionOrder ProductionOrder { get; set; }
        public virtual ICollection<PalletPackingDetails> PalletPackingDetails { get; set; }
    }
}
