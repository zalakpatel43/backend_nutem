using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductInstructionDetailsRepository : GenericRepository<ProductInstructionDetails>, IProductInstructionDetailsRepository
    {
        public ProductInstructionDetailsRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<ProductInstructionDetails> GetProductInstructionByProductId(long id)
        {
            return _context.ProductInstructionDetails
                .Include(wc => wc.MaterialMaster) 
                .Where(wc => wc.IsActive && wc.ProductId == id);
        }
    }
}
