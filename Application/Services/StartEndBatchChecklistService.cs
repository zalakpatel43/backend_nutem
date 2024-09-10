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
    public class StartEndBatchChecklistService : IStartEndBatchChecklistService
    {
        private readonly IStartEndBatchChecklistRepository _startEndBatchChecklistRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public StartEndBatchChecklistService(IStartEndBatchChecklistRepository startEndBatchChecklistRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _startEndBatchChecklistRepository = startEndBatchChecklistRepository;
            _dataMapper = dataMapper;
        }
        public IQueryable<StartEndBatchCheckListList> GetAllStartEndBatchChecklistAsync()
        {
            var entity = _startEndBatchChecklistRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<StartEndBatchChecklist, StartEndBatchCheckListList>(entity);
        }
    }
}
