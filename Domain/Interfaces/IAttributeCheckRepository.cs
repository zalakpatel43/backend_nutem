using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAttributeCheckRepository : IGenericRepository<AttributeCheck>
    {
        Task<AttributeCheck> GetByIdAsync(long id);
        // Add methods specific to AttributeCheck if needed
    }
}
