using Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDowntimeTrackingService
    {
        Task<IEnumerable<DowntimeTrackingList>> GetAllDowntimeTrackingsAsync();
        Task<DowntimeTrackingAddEdit> GetDowntimeTrackingByIdAsync(long id);
        Task<long> AddDowntimeTrackingAsync(DowntimeTrackingAddEdit model, long userId);
        Task<long> UpdateDowntimeTrackingAsync(DowntimeTrackingAddEdit model, long userId);
        Task DeleteDowntimeTrackingAsync(long id, long userId);
    }
}
