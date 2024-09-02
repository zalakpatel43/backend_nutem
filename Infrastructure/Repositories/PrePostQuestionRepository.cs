using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class PrePostQuestionRepository : GenericRepository<PrePostQuestionEntity>, IPrePostQuestionRepository
    {
        public PrePostQuestionRepository(AppDbContext context) : base(context)
        {
        }

        // Implement methods specific to PrePostQuestion if needed
    }
}
