using Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPreCheckListService
    {
        Task<IEnumerable<PreCheckList>> GetAllPreCheckListAsync();
        Task<PreCheckListAddEdit> GetPreCheckListByIdAsync(long id);
        Task<long> AddPreCheckListAsync(PreCheckListAddEdit model, long user);
        Task<long> UpdatePreCheckListAsync(PreCheckListAddEdit model, long user);
        Task DeletePreCheckListAsync(long id, long user);
    }
}
