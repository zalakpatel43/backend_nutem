using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITrailerLoadingRepository : IGenericRepository<TrailerLoading>
    {
        IQueryable<TrailerLoading> GetAllTrailerLoadingsWithDetails();

        Task<TrailerLoading> GetByIdAsync(long id);
    }
}
