using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class PalletPackingAddEdit
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? PackingDateTime { get; set; }
        public long? SAPProductionOrderId { get; set; }
        public long? ProductId { get; set; }
        public decimal? FinishedCasesOnIncompletePalletAtStart { get; set; }
        public decimal? FinishedCasesOnIncompletePalletAtEnd { get; set; }
        public decimal? TotalCasesProduced { get; set; }
        public long? SupervisedId { get; set; }
        public string Notes { get; set; }
        public bool? IsActive { get; set; }

        // No details collection in this case, as specified
        public List<PalletPackingDetailsAddEdit> PalletPackingDetails { get; set; } = new List<PalletPackingDetailsAddEdit>();

        public string PackingDT
        {
            get
            {
                string formatDate = "";
                if (PackingDateTime != null && PackingDateTime != DateTime.MinValue)
                {
                    formatDate = PackingDateTime.Value.ToString("dd-MMM-yyyy hh:mm tt");
                }
                return formatDate;
            }
        }
    }
}
