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
    public class ProductInstructionDetailsService : IProductInstructionDetailsService
    {
        private readonly IProductInstructionDetailsRepository _productInstructionDetailsRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public ProductInstructionDetailsService(IProductInstructionDetailsRepository productInstructionDetailsRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _productInstructionDetailsRepository = productInstructionDetailsRepository;
            _dataMapper = dataMapper;
        }
        public IQueryable<ProductInstructionDetailsList> GetAllProductInstructionAsync()
        {
            var entity = _productInstructionDetailsRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<ProductInstructionDetails, ProductInstructionDetailsList>(entity);
        }
    }
}
