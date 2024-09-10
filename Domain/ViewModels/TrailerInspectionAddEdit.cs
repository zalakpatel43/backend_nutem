using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class TrailerInspectionAddEdit
    {
        //public TrailerInspectionAddEdit()
        //{

        //}

        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime? Date { get; set; }
        public long? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public long? InspectedById { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public string TotalTime { get; set; }
        public DateTime? TimeOfInspection { get; set; }
        public string Mode { get; set; }
        public string DriverName { get; set; }
        public long? VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public string LicensePlateNo { get; set; }
        public string TrailerNo { get; set; }
        public string TruckNo { get; set; }
        public string VehicleStatus { get; set; }
        public string RejectionReason { get; set; }
        public string VehicleCleanAns { get; set; }
        public string VehicleCleanNotes { get; set; }
        public string ComingOrderFromForeignAns { get; set; }
        public string ComingOrderFromForeignNotes { get; set; }
        public string DoorCloseProperlyAns { get; set; }
        public string DoorCloseProperlyNotes { get; set; }
        public string OverallIntegrityAns { get; set; }
        public string OverallIntegrityNotes { get; set; }
        public string FloorInGoodConditionAns { get; set; }
        public string FloorInGoodConditionNotes { get; set; }
        public string PresentOnTrailerAns { get; set; }
        public string PresentOnTrailerNotes { get; set; }
        public string SafeWorkingOrderAns { get; set; }
        public string SafeWorkingOrderNotes { get; set; }
        public string IsRustPresentAns { get; set; }
        public string IsRustPresentNotes { get; set; }
        public string TemperatureSettingUsedAns { get; set; }
        public string TemperatureSettingUsedNotes { get; set; }

        public string formatDT
        {
            get
            {
                string formatDate = "";
                if (Date != null && Date != DateTime.MinValue)
                {
                    formatDate = Date.Value.ToString("dd-MMM-yyyy hh:MM tt");
                }
                return formatDate;
            }
        }
    }
}
