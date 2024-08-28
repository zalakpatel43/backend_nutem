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
    public class WeightCheckRepository : GenericRepository<WeightCheck>, IWeightCheckRepository
    {
        public WeightCheckRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<WeightCheck> GetAllWeightChecksWithProduct()
        {
            return _context.WeightCheck
                .Include(wc => wc.ShiftMaster) // Ensure the navigation property is included
                .Where(wc => wc.IsActive);
        }

        public async Task<WeightCheck> GetByIdAsync(long id)
        {
            return await _context.WeightCheck
                .Include(w => w.WeightCheckDetails)
                    .ThenInclude(d => d.WeightCheckSubDetails)  // Include WeightCheckSubDetails
                .SingleOrDefaultAsync(w => w.Id == id);
        }

        // Implement methods specific to Company if needed
    }
}
