using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("adm_PalletPackingDetails")]
    public class PalletPackingDetails : BaseAuditable
    {
        public long? HeaderId { get; set; }
        public string PalletNo { get; set; }
        public DateTime? Time { get; set; }
        public string DoneByIds { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual PalletPacking PalletPacking { get; set; }
    }
}
