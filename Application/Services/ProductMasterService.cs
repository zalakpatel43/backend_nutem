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
    public class ProductMasterService : IProductMasterService
    {
        private readonly IProductMasterRepository _productMasterRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public ProductMasterService(IProductMasterRepository productMasterRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _productMasterRepository = productMasterRepository;
            _dataMapper = dataMapper;
        }
        public IQueryable<ProdcutMasterList> GetAllProductMasterAsync()
        {
            var entity = _productMasterRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<ProductMaster, ProdcutMasterList>(entity);
        }
    }
}
