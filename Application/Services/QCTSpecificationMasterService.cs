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
    public class QCTSpecificationMasterService : IQCTSpecificationMasterService
    {
        private readonly IQCTSpecificationMasterRepository _qCTSpecificationMasterRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public QCTSpecificationMasterService(IQCTSpecificationMasterRepository qCTSpecificationMasterRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _qCTSpecificationMasterRepository = qCTSpecificationMasterRepository;
            _dataMapper = dataMapper;
        }
        public IQueryable<QCTSpecificationMasterList> GetAllQCTSpecificationMasterAsync()
        {
            var entity = _qCTSpecificationMasterRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<QCTSpecificationMaster, QCTSpecificationMasterList>(entity);
        }
    }
}
