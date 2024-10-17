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
    public class LaborVarinceRepository : GenericRepository<LaborVariance>, ILaborVarinceRepository
    {
        public LaborVarinceRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<LaborVariance> GetAllLaborVarinceProduct()
        {
            return _context.LaborVariance
                .Include(wc => wc.ShiftMaster)
                .Include(wc => wc.Masters)   // Ensure the navigation property is included
            .Where(wc => wc.IsActive);
        }

        public async Task<LaborVariance> GetByIdAsync(long id)
        {
            return await _context.LaborVariance
                .Include(w => w.LaborVarianceDetails)
                .SingleOrDefaultAsync(w => w.Id == id);
        }

        // Implement methods specific to Company if needed
    }
}
