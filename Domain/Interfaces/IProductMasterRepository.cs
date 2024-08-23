using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductMasterRepository : IGenericRepository<ProductMaster>
    {
        // Add methods specific to Company if needed
    }

}
