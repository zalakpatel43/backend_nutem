using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class ProductionOrderDetailsDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public decimal? PlannedQty { get; set; }
        public string ItemName { get; set; }

        public List<WeightCheckDto> WeightChecks { get; set; }
        public List<AttributeCheckDto> AttributeChecks { get; set; }
        public List<PreCheckListEntityDto> PreCheckListEntities { get; set; }
        public List<PostCheckListEntityDto> PostCheckListEntities { get; set; }
    }

    public class WeightCheckDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public long? SAPProductionOrderId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long ShiftId { get; set; }
        public string ShiftName { get; set; }
    }

    public class AttributeCheckDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime ACDate { get; set; }
        public long ProductionOrderId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string BottleDateCode { get; set; }
        public string PackSize { get; set; }
        public bool IsWeightRange { get; set; }
    }

    public class PreCheckListEntityDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime StartDateTime { get; set; }
        public long ProductionOrderId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long ShiftId { get; set; }
        public string ShiftName { get; set; }
        public int FillingLine { get; set; }
        public string FillingLineNumber { get; set; }
        public string FillerUserIds { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public string StartDateTimeFormatted { get; set; }
    }

    public class PostCheckListEntityDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime EndDateTime { get; set; }
        public long ProductionOrderId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long ShiftId { get; set; }
        public string ShiftName { get; set; }
        public int FillingLine { get; set; }
        public string FillingLineNumber { get; set; }
        public string FillerUserIds { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public string EndDateTimeFormatted { get; set; }
    }
}
