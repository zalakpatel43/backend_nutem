using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostCheckListRepository : GenericRepository<PostCheckListEntity>, IPostCheckListRepository
    {
        public PostCheckListRepository(AppDbContext context) : base(context)
        {
        }

        public virtual async Task<IEnumerable<PostCheckListEntity>> GetAllAsync()
        {
            return await _context.PostCheckListEntity
                                 .Include(pcl => pcl.ProductMaster) // Include ProductMaster
                                 .Include(pcl => pcl.ShiftMaster)   // Include ShiftMaster
                                 .Include(pcl => pcl.PostCheckListDetails)
                                 .Include(pcl => pcl.Masters)// Include PostCheckListDetails
                                 .ToListAsync();
        }

        public async Task<PostCheckListEntity> GetByIdAsync(long id)
        {
            return await _context.PostCheckListEntity
                                 .Include(pcl => pcl.ProductMaster) // Include ProductMaster
                                 .Include(pcl => pcl.ShiftMaster)   // Include ShiftMaster
                                 .Include(pcl => pcl.PostCheckListDetails) // Include PostCheckListDetails
                                 .FirstOrDefaultAsync(pcl => pcl.Id == id);
        }
    }
}
