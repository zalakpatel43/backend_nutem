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
    public class PalletPackingRepository : GenericRepository<PalletPacking>, IPalletPackingRepository
    {
        public PalletPackingRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<PalletPacking> GetAllPalletPackingsWithProduct()
        {
            return _context.PalletPacking
                .Include(pp => pp.ProductMaster)
                .Include(pp => pp.ProductionOrder)
                .Where(pp => pp.IsActive);
        }

        public async Task<PalletPacking> GetByIdAsync(long id)
        {
            return await _context.PalletPacking
                .Include(pp => pp.ProductMaster)
                .Include(pp => pp.PalletPackingDetails)  // Include PalletPackingDetails
                .SingleOrDefaultAsync(pp => pp.Id == id);
        }

        // Implement methods specific to PalletPacking if needed
    }
}
