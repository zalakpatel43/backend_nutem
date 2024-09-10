using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Skyward.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MastersService : IMastersService
    {
        private readonly IMastersRepository _mastersRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public MastersService(IMastersRepository mastersRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _mastersRepository = mastersRepository;
            _dataMapper = dataMapper;
        }

        public IQueryable<MastersList> GetAllMastersAsync()
        {
            var entity = _mastersRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<MastersEntity, MastersList>(entity);
        }

        public async Task<IEnumerable<MastersEntity>> GetVehicleTypeCategoriesAsync()
        {
            return await _mastersRepository.GetByCategoryNameAsync("VehicleType");
        }
    }
}
