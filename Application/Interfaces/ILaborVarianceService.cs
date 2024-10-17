using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILaborVarianceService
    {
        IQueryable<LaborVarianceList> GetAllLaborVarianceAsync();
        Task<LaborVarianceAddEdit> GetLaborVarianceByIdAsync(long id);
        Task<long> AddLaborVarianceAsync(LaborVarianceAddEdit model, long user);
        Task<long> UpdateLaborVarianceAsync(LaborVarianceAddEdit model, long user);
        Task DeleteLaborVarianceAsync(long id, long user);
    }
}
