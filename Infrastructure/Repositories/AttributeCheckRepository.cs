using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AttributeCheckRepository : GenericRepository<AttributeCheck>, IAttributeCheckRepository
    {
        public AttributeCheckRepository(AppDbContext context) : base(context)
        {
        }

        public virtual async Task<IEnumerable<AttributeCheck>> GetAllAsync()
        {
            return await _context.AttributeCheck
                                 .Include(ac => ac.ProductMaster) // Assuming Product is the navigation property
                                 .Where(wc => wc.IsActive) 
                                 .ToListAsync();
        }

        public async Task<AttributeCheck> GetByIdAsync(long id)
        {
            return await _context.AttributeCheck
                .Include(w => w.AttributeCheckDetails)
                .SingleOrDefaultAsync(w => w.Id == id);
        }
    }
}
