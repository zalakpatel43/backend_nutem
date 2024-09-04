using Skyward.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class TrailerInspectionList
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string DriverName { get; set; }
        public long? VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public string LicensePlateNo { get; set; }
        public bool IsActive { get; set; }
        public long? CompanyId { get; set; }
        public string CompanyName { get; set; }

    }
}
