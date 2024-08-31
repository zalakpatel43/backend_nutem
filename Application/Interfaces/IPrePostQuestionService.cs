using Domain.ViewModels;
using System.Linq;

namespace Application.Interfaces
{
    public interface IPrePostQuestionService
    {
        IQueryable<PrePostQuestionList> GetAllPrePostQuestionsAsync();
    }
}
