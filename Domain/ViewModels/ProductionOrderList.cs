using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class ProductionOrderList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public decimal? PlannedQty { get; set; }
        public string ItemName { get; set; }

        public string PODateTimeFormatted
        {
            get
            {
                return PODate.HasValue ? PODate.Value.ToString("dd-MMM-yyyy hh:mm tt") : "N/A";
            }
        }
        // New properties for related data
        public List<WeightCheckList> WeightChecks { get; set; }
        public List<AttributeCheckList> AttributeChecks { get; set; }
        public List<PreCheckList> PreCheckListEntities { get; set; }
        public List<PostCheckList> PostCheckListEntities { get; set; }
    }
}
