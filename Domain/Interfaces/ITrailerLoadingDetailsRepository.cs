using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITrailerLoadingDetailsRepository : IGenericRepository<TrailerLoadingDetails>
    {
        // Add methods specific to TrailerLoadingDetails if needed
        Task<IEnumerable<TrailerLoadingDetails>> GetAllAsync();
    }
}
