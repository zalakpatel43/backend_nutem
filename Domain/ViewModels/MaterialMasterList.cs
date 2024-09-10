using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class MaterialMasterList
    {
        public MaterialMasterList()
        {

        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string MaterialName { get; set; }
        public string PartCode { get; set; }
    }
}
