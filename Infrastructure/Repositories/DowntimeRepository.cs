using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class DowntimeTrackingRepository : GenericRepository<DowntimeTracking>, IDowntimeTrackingRepository
    {
        public DowntimeTrackingRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<DowntimeTracking> GetAllDowntimeTrackingsWithDetails()
        {
            return _context.DowntimeTracking
                .Include(d => d.DownTimeTrackingDetails)  // Ensure this navigation property is included
                .Where(d => d.IsActive); // Optional: Filter based on `IsActive` if needed
        }
    }
}
