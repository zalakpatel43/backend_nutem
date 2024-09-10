using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPalletPackingRepository : IGenericRepository<PalletPacking>
    {
        IQueryable<PalletPacking> GetAllPalletPackingsWithProduct();

        Task<PalletPacking> GetByIdAsync(long id);
    }
}
