using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TrailerLoadingRepository : GenericRepository<TrailerLoading>, ITrailerLoadingRepository
    {
        public TrailerLoadingRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<TrailerLoading> GetAllTrailerLoadingsWithDetails()
        {
            return _context.Set<TrailerLoading>()
                .Include(t => t.TrailerLoadingDetails) // Include related details
                .Include(t => t.HeadUser)
                     .Where(t => t.IsActive);
        }

        public async Task<TrailerLoading> GetByIdAsync(long id)
        {
            return await _context.Set<TrailerLoading>()
                .Include(t => t.TrailerLoadingDetails) // Include related
                .Include(t => t.HeadUser)
                .FirstOrDefaultAsync(t => t.Id == id);
        }


    }
}
