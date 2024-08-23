using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductionOrderRepository : GenericRepository<ProductionOrder>, IProductionOrderRepository
    {
        public ProductionOrderRepository(AppDbContext context) : base(context)
        {
        }

        // Implement methods specific to Company if needed
    }
}
