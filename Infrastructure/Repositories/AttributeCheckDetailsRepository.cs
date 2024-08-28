using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class AttributeCheckDetailsRepository : GenericRepository<AttributeCheckDetails>, IAttributeCheckDetailsRepository
    {
        public AttributeCheckDetailsRepository(AppDbContext context) : base(context)
        {
        }

        // Implement methods specific to AttributeCheckDetails if needed
    }
}
