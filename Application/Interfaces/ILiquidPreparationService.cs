using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILiquidPreparationService
    {
        IQueryable<LiquidPreparationList> GetAllLiquidPreparationAsync();
        Task<LiquidPreparationAddEdit> GetLiquidPreparationByIdAsync(long id);
        Task<long> AddLiquidPreparationAsync(LiquidPreparationAddEdit model, long user);
        Task<long> UpdateLiquidPreparationAsync(LiquidPreparationAddEdit model, long user);
        Task DeletLiquidPreparationAsync(long id, long user);

    }
}
