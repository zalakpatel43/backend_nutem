using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class QCTSpecificationMasterList
    {
        public QCTSpecificationMasterList()
        {
        }

        public long Id { get; set; }
        public string SpecificationCode { get; set; }
        public string SpecificationName { get; set; }
        public string HighValue { get; set; }
        public string LowValue { get; set; }

    }
}
