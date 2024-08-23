using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class NozzleMasterList
    {
        public long Id { get; set; }
        public string NozzelCode { get; set; }
        public string? NozzelName { get; set; }
        public bool? IsActive { get; set; }
    }


}
