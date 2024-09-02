using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using System.Linq;

namespace Application.Services
{
    public class PrePostQuestionService : IPrePostQuestionService
    {
        private readonly IPrePostQuestionRepository _prePostQuestionRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public PrePostQuestionService(IPrePostQuestionRepository prePostQuestionRepository,
                                      IAutoMapperGenericDataMapper dataMapper)
        {
            _prePostQuestionRepository = prePostQuestionRepository;
            _dataMapper = dataMapper;
        }

        public IQueryable<PrePostQuestionList> GetAllPrePostQuestionsAsync()
        {
            var entities = _prePostQuestionRepository.Get(m => m.IsActive == true);
            return _dataMapper.Project<PrePostQuestionEntity, PrePostQuestionList>(entities);
        }
    }
}
