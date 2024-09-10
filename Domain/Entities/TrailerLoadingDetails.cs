using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_TrailerLoadingDetails")]
    public class TrailerLoadingDetails : BaseAuditable
    {
        public long? HeaderId { get; set; }
        public long? ProductId { get; set; }
        public int PalletQty { get; set; }
        //public string PO { get; set; }
        public long? ProductionOrder { get; set; }
        public long? ActionTakenBy { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual TrailerLoading TrailerLoading { get; set; }
        public virtual ProductionOrder ProductionOrderid { get; set; }
 
    }
}
