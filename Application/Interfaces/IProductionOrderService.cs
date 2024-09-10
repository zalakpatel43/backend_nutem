using Domain.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductionOrderService
    {
        IQueryable<ProductionOrderList> GetAllProductionOrderAsync();
        Task<ProductionOrderList> GetProductionOrderByIdAsync(long id);
    }
}
