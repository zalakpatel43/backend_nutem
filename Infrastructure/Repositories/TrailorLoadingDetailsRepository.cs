using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TrailerLoadingDetailsRepository : GenericRepository<TrailerLoadingDetails>, ITrailerLoadingDetailsRepository
    {
        public TrailerLoadingDetailsRepository(AppDbContext context) : base(context)
        {
        }

        // Implement methods specific to TrailerLoadingDetails if needed
    }
}
