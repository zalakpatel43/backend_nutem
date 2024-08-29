using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDowntimeTrackingRepository : IGenericRepository<DowntimeTracking>
    {
        IQueryable<DowntimeTracking> GetAllDowntimeTrackingsWithDetails();
    }
}
