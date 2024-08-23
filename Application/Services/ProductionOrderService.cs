using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var entity = _productionOrderRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<ProductionOrder, ProductionOrderList>(entity);
        }
    }
}
