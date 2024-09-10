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
    public class MaterialMasterService : IMaterialMasterService
    {
        private readonly IMaterialMasterRepository _materialMasterRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public MaterialMasterService(IMaterialMasterRepository materialMasterRepositoryRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _materialMasterRepository = materialMasterRepositoryRepository;
            _dataMapper = dataMapper;
        }
        public IQueryable<MaterialMasterList> GetAllMaterialMasterAsync()
        {
            var entity = _materialMasterRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<MaterialMaster, MaterialMasterList>(entity);
        }
    }
}
