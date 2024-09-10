using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostCheckListDetailRepository : GenericRepository<PostCheckListDetailEntity>, IPostCheckListDetailRepository
    {
        public PostCheckListDetailRepository(AppDbContext context) : base(context)
        {
        }

        public virtual async Task<IEnumerable<PostCheckListDetailEntity>> GetAllAsync()
        {
            return await _context.PostCheckListDetailEntity
                                 .Include(pcld => pcld.PrePostQuestion) // Assuming PrePostQuestion is the navigation property
                                 .Include(pcld => pcld.PostCheckList)    // Assuming PostCheckList is the navigation property
                                 .ToListAsync();
        }

        // Implement methods specific to PostCheckListDetailEntity if needed
    }
}
