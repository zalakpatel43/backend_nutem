using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PreCheckListDetailRepository : GenericRepository<PreCheckListDetailEntity>, IPreCheckListDetailRepository
    {
        public PreCheckListDetailRepository(AppDbContext context) : base(context)
        {
        }

        public virtual async Task<IEnumerable<PreCheckListDetailEntity>> GetAllAsync()
        {
            return await _context.PreCheckListDetailEntity
                                 .Include(pcld => pcld.PrePostQuestion) // Assuming PrePostQuestion is the navigation property
                                 .Include(pcld => pcld.PreCheckList)    // Assuming PreCheckList is the navigation property
                                 .ToListAsync();
        }

        // Implement methods specific to PreCheckListDetailEntity if needed
    }
}
