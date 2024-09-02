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
    public class CompanyMasterService : ICompanyMasterService
    {
        private readonly ICompanyMasterRepository _companyMasterRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public CompanyMasterService(ICompanyMasterRepository companyMasterRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _companyMasterRepository = companyMasterRepository;
            _dataMapper = dataMapper;
        }
        public IQueryable<CompanyMasterList> GetAllCompanyMasterAsync()
        {
            var entity = _companyMasterRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<CompanyMaster, CompanyMasterList>(entity);
        }
    }
}
