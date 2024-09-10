using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TrailerInspectionRepository : GenericRepository<TrailerInspection>, ITrailerInspectionRepository
    {
        public TrailerInspectionRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<TrailerInspection> GetAllTrailerInspectionWithVehicleTypeName()
        {
            return _context.TrailerInspection
                .Include(wc => wc.MasterEntity)
                .Include(cm => cm.CompanyMaster)// Ensure the navigation property is included
            .Where(wc => wc.IsActive);
        }

        // Implement methods specific to Company if needed
    }
}
