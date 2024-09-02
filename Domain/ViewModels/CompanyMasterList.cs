using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CompanyMasterList
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string CompanyName { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }
    }
}
