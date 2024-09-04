using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostCheckListRepository : IGenericRepository<PostCheckListEntity>
    {
        Task<IEnumerable<PostCheckListEntity>> GetAllAsync();
        // Add other methods specific to PostCheckListEntity if needed
    }
}
