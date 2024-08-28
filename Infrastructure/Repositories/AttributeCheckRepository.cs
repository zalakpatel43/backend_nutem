using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class AttributeCheckRepository : GenericRepository<AttributeCheck>, IAttributeCheckRepository
    {
        public AttributeCheckRepository(AppDbContext context) : base(context)
        {
        }

        // Implement methods specific to AttributeCheck if needed
    }
}
