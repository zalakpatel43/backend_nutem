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
    public class TankMasterService : ITankMasterService
    {
        private readonly ITankMasterRepository _tankMasterRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public TankMasterService(ITankMasterRepository tankMasterRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _tankMasterRepository = tankMasterRepository;
            _dataMapper = dataMapper;
        }
        public IQueryable<TankMasterList> GetAllTankMasterAsync()
        {
            var entity = _tankMasterRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<TankMaster, TankMasterList>(entity);
        }
    }
}
