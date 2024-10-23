using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProductInstructionDetailsList
    {
        public ProductInstructionDetailsList()
        {
        }

        public long Id { get; set; }
        public long? ProductId { get; set; }
        public string Instruction { get; set; }
        public decimal? Weight { get; set; }
        public long? MaterialId { get; set; } // material master id
        public string MaterialName { get; set; }

    }
}
