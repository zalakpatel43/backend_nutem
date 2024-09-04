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
    public class CompanyMasterRepository : GenericRepository<CompanyMaster>, ICompanyMasterRepository
    {
        public CompanyMasterRepository(AppDbContext context) : base(context)
        {
        }

        // Implement methods specific to Company if needed
    }
}
