using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductInstructionDetailsRepository : IGenericRepository<ProductInstructionDetails>
    {
        IQueryable<ProductInstructionDetails> GetProductInstructionByProductId(long id);
    }
}
