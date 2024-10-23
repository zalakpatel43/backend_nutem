using System;

namespace Domain.ViewModels
{
    public class PalletPackingList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? PackingDateTime { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? TotalCasesProduced { get; set; }
        public long? SAPProductionOrderId { get; set; }
        public string PONumber { get; set; }

        // Additional properties can be added as needed
    }
}
