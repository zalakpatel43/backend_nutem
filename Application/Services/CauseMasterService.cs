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
    public class CauseMasterService : ICauseMasterService
    {
        private readonly ICauseMasterRepository _causeMasterRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public CauseMasterService(ICauseMasterRepository causeMasterRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _causeMasterRepository = causeMasterRepository;
            _dataMapper = dataMapper;
        }

        public IQueryable<CauseMasterList> GetAllCauseMastersAsync()
        {
            var entity = _causeMasterRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<CauseMaster, CauseMasterList>(entity);
        }
    }
}
