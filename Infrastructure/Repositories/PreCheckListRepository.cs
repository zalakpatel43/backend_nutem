using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PreCheckListRepository : GenericRepository<PreCheckListEntity>, IPreCheckListRepository
    {
        public PreCheckListRepository(AppDbContext context) : base(context)
        {
        }

        public virtual async Task<IEnumerable<PreCheckListEntity>> GetAllAsync()
        {
            return await _context.PreCheckListEntity
                                 .Include(pcl => pcl.ProductMaster)
                                 .Include(pcl => pcl.ShiftMaster)
                                 .Include(pcl => pcl.PreCheckListDetails)
                                 .ToListAsync();
        }

        public async Task<PreCheckListEntity> GetByIdAsync(long id)
        {
            return await _context.PreCheckListEntity
                                 .Include(pcl => pcl.ProductMaster) // Include ProductMaster
                                 .Include(pcl => pcl.ShiftMaster)   // Include ShiftMaster
                                 .Include(pcl => pcl.PreCheckListDetails) // Include PreCheckListDetails
                                 .FirstOrDefaultAsync(pcl => pcl.Id == id);
        }

    }
}
