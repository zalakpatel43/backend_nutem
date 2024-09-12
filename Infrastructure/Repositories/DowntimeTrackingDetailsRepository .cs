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
    public class DowntimeTrackingDetailsRepository : GenericRepository<DowntimeTrackingDetails>, IDowntimeTrackingDetailsRepository
    {
        public DowntimeTrackingDetailsRepository(AppDbContext context) : base(context)
        {
        }
        public async Task UpdateAsync(DowntimeTrackingDetails entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        // Implement methods specific to DowntimeTrackingDetails if needed
    }
}
