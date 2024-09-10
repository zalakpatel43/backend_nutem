using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class TankMasterList
    {
        public TankMasterList()
        {
        }

        public long Id { get; set; }
        public string TankCode { get; set; }
        public string TankName { get; set; }
    }
}
