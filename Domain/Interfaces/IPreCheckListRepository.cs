using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPreCheckListRepository : IGenericRepository<PreCheckListEntity>
    {
        Task<IEnumerable<PreCheckListEntity>> GetAllAsync();
        // Add other methods specific to PreCheckListEntity if needed
    }
}
