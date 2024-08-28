using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Skyward.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MastersRepository : GenericRepository<MastersEntity>, IMastersRepository
    {
        public MastersRepository(AppDbContext context) : base(context)
        {
        }

        // Implement methods specific to MastersEntity if needed
    }
}
