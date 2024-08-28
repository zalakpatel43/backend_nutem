using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NozzleMasterService : INozzleMasterService
    {
        private readonly INozzleMasterRepository _NozzleMasterRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public NozzleMasterService(INozzleMasterRepository nozzleMasterRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _NozzleMasterRepository = nozzleMasterRepository;
            _dataMapper = dataMapper;
        }
        //public IQueryable<NozzleMasterList> GetAllNozzleMasterAsync()
        //{
        //    var entity = _NozzleMasterRepository.Get(m => m.IsActive == true);
        //    return _dataMapper.Project<NozzelMaster, NozzleMasterList>(entity);
        //}
        public async Task<PaginatedList<NozzleMasterList>> GetAllNozzleMasterAsync(PaginationRequest paginationRequest)
        {
            var pagedData = await _NozzleMasterRepository.GetPagedDataAsync(paginationRequest.PageNumber, paginationRequest.PageSize);
            return _dataMapper.Map<PaginatedList<NozzelMaster>, PaginatedList<NozzleMasterList>>(pagedData);
        }
    }
}
