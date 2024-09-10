using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductionOrderRepository : IGenericRepository<ProductionOrder>
    {
        Task<ProductionOrder> GetProductionOrderWithDetailsByIdAsync(long id);
    }
}
