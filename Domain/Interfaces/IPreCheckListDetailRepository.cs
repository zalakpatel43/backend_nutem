using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPreCheckListDetailRepository : IGenericRepository<PreCheckListDetailEntity>
    {
        Task<IEnumerable<PreCheckListDetailEntity>> GetAllAsync();
        // Add other methods specific to PreCheckListDetailEntity if needed
    }
}
