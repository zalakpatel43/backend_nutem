using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAttributeCheckDetailsRepository : IGenericRepository<AttributeCheckDetails>
    {
        Task<IEnumerable<AttributeCheckDetails>> GetAllAsync();
    }
}
