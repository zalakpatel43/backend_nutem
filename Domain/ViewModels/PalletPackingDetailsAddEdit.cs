using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class PalletPackingDetailsAddEdit
    {
        public long Id { get; set; }
        public long? PalletPackingId { get; set; }
        public string PalletNo { get; set; }
        public DateTime? Time { get; set; }
        public string DoneByIds { get; set; }
        public bool? IsActive { get; set; }

        // No sub-details collection, as specified
    }
}
