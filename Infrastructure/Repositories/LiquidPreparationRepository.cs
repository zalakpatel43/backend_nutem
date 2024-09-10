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
    public class LiquidPreparationRepository : GenericRepository<LiquidPreparation>, ILiquidPreparationRepository
    {
        public LiquidPreparationRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<LiquidPreparation> GetAllLiquidPreparationWithShift()
        {
            return _context.LiquidPreparation
                .Include(wc => wc.ShiftMaster) // Ensure the navigation property is included
                .Where(wc => wc.IsActive);
        }

        public async Task<LiquidPreparation> GetByIdAsync(long id)
        {
            return
                await _context.LiquidPreparation
                .Include(w => w.LiquidPreparationChecklistDetails)
                .Include(w => w.LiquidPreparationAdjustmentDetails)
                .Include(w => w.LiquidPreparationInstructionDetails)
                .Include(w => w.LiquidPreparationSpecificationDetails)
                // .ThenInclude(d => d.Li)  // Include WeightCheckSubDetails
                .SingleOrDefaultAsync(w => w.Id == id);
        }

        // Implement methods specific to Company if needed
    }
}
