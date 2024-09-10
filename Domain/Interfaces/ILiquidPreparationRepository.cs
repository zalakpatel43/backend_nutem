using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILiquidPreparationRepository : IGenericRepository<LiquidPreparation>
    {
        IQueryable<LiquidPreparation> GetAllLiquidPreparationWithShift();

        Task<LiquidPreparation> GetByIdAsync(long id);
        // Add methods specific to Company if needed
    }
}
