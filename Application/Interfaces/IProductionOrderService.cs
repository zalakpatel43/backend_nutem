using Domain.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductionOrderService
    {
        IQueryable<ProductionOrderList> GetAllProductionOrderAsync();
        IQueryable<ProductionOrderList> GetPOByStatus(String status);
        Task<ProductionOrderList> GetProductionOrderByIdAsync(long id);
        Task<bool> ToggleProductionOrderStatusAsync(long id);

        Task<ResponseModel> GetAllProductionOrdersFromSAP();
    }
}
