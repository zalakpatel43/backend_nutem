using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductionOrderService : IProductionOrderService
    {
        private readonly IProductionOrderRepository _productionOrderRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public ProductionOrderService(IProductionOrderRepository productionOrderRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _productionOrderRepository = productionOrderRepository;
            _dataMapper = dataMapper;
        }

        public IQueryable<ProductionOrderList> GetAllProductionOrderAsync()
        {
            var entities = _productionOrderRepository.Get(m => m.IsActive == true);
            var productionOrderLists = _dataMapper.Project<ProductionOrder, ProductionOrderList>(entities);
            return productionOrderLists.AsQueryable(); // Ensure you return IQueryable
        }

        public async Task<ProductionOrderList> GetProductionOrderByIdAsync(long id)
        {
            var entity = await _productionOrderRepository.GetProductionOrderWithDetailsByIdAsync(id);
            if (entity == null)
                return null;

            return new ProductionOrderList
            {
                Id = entity.Id,
                Code = entity.Code,
                PONumber = entity.PONumber,
                PODate = entity.PODate,
                PlannedQty = entity.PlannedQty,
                ItemName = entity.ItemName,
                Status=entity.Status,

                // Map WeightChecks 
                WeightChecks = entity.WeightCheck.Select(wc => new WeightCheckList
                {
                    Id=wc.Id,
                    Code = wc.Code,
                    StartDateTime = wc.StartDateTime,
                    EndDateTime = wc.EndDateTime,
                    ProductId = wc.ProductId,
                    ProductName = wc.ProductMaster?.ProductName, 
                    ShiftName = wc.ShiftMaster?.ShiftName, 
                                                           
                }).ToList(),

                // Map AttributeChecks 
                AttributeChecks = entity.AttributeCheck.Select(ac => new AttributeCheckList
                {   
                    Id=ac.Id,
                    Code = ac.Code,
                    ACDate = ac.ACDate,
                    ProductId = ac.ProductId,
                    ProductName = ac.ProductMaster?.ProductName, 
                                                                 
                }).ToList(),

                // Map PreCheckListEntities 
                PreCheckListEntities = entity.PreCheckListEntity.Select(pre => new PreCheckList
                {
                    Id=pre.Id,
                    Code = pre.Code,
                    StartDateTime = pre.StartDateTime,
                    ProductId = pre.ProductId,
                    ProductName = pre.ProductMaster?.ProductName, 
                    ShiftName = pre.ShiftMaster?.ShiftName, 
                                                            
                }).ToList(),

                // Map PostCheckListEntities 
                PostCheckListEntities = entity.PostCheckListEntity.Select(post => new PostCheckList
                {   
                    Id = post.Id,
                    Code = post.Code,
                    EndDateTime = post.EndDateTime,
                    ProductId = post.ProductId,
                    ProductName = post.ProductMaster?.ProductName,
                    ShiftName = post.ShiftMaster?.ShiftName, 
                                                             
                }).ToList(),

                PalletPackingList = entity.PalletPacking.Select(pp => new PalletPackingList
                {
                    Id = pp.Id,
                    Code = pp.Code,
                    PackingDateTime = pp.PackingDateTime,
                    ProductId = pp.ProductId,
                    ProductName = pp.ProductMaster?.ProductName,
                    //ShiftName = post.ShiftMaster?.ShiftName,

                }).ToList()
            };
        }
        public async Task<bool> ToggleProductionOrderStatusAsync(long id)
        {
            var entity = await _productionOrderRepository.GetProductionOrderWithDetailsByIdAsync(id);
            if (entity == null)
                return false;

            // Toggle status between "Open" and "Closed"
            entity.Status = entity.Status == "Open" ? "Closed" : "Open";

            // Save changes
            await _productionOrderRepository.UpdateAsync(entity);
            return true;
        }


    }
}
