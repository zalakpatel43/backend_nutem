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
    public class ShiftMasterService : IShiftMasterService
    {
        private readonly IShiftMasterRepository _shiftMasterRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;
        private readonly IClaimAccessorService _claimAccessorService;

        public ShiftMasterService(IShiftMasterRepository shiftMasterRepository,
            IAutoMapperGenericDataMapper dataMapper,
            IClaimAccessorService claimAccessorService)
        {
            _shiftMasterRepository = shiftMasterRepository;
            _dataMapper = dataMapper;
            _claimAccessorService = claimAccessorService;
        }
        public IQueryable<ShiftMasterList> GetAllShiftMasterAsync()
        {
            long loggedinuserId = _claimAccessorService.GetUserId();
            var entity = _shiftMasterRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<ShiftMaster, ShiftMasterList>(entity);
        }
    }
}
