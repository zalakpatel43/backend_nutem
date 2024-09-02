using Domain.ViewModels; 
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAttributeCheckService
    {
        Task<IEnumerable<AttributeCheckList>> GetAllAttributeCheckAsync();
        Task<AttributeCheckAddEdit> GetAttributeCheckByIdAsync(long id);
        Task<long> AddAttributeCheckAsync(AttributeCheckAddEdit model, long user);
        Task<long> UpdateAttributeCheckAsync(AttributeCheckAddEdit model, long user);
        Task DeleteAttributeCheckAsync(long id, long user);
    }
}
