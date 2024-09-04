using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostCheckListDetailRepository : IGenericRepository<PostCheckListDetailEntity>
    {
        Task<IEnumerable<PostCheckListDetailEntity>> GetAllAsync();
        // Add other methods specific to PostCheckListDetailEntity if needed
    }
}
