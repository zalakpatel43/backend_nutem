using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWeightCheckService
    {
        IQueryable<WeightCheckList> GetAllWeightCheckAsync();
        Task<WeightCheckAddEdit> GetWeightCheckByIdAsync(long id);
        Task<long> AddWeightCheckAsync(WeightCheckAddEdit model, long user);
        Task<long> UpdateWeightCheckAsync(WeightCheckAddEdit model, long user);
        Task DeleteWeightCheckAsync(long id, long user);
    }
}
