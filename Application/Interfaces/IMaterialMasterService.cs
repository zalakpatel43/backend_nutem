using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMaterialMasterService
    {
        IQueryable<MaterialMasterList> GetAllMaterialMasterAsync();
        //Task<WeightCheckAddEdit> GetWeightCheckByIdAsync(long id);
        //Task<long> AddWeightCheckAsync(WeightCheckAddEdit model, Guid user);
        //Task<long> UpdateWeightCheckAsync(WeightCheckAddEdit model, Guid user);
        //Task DeleteWeightCheckAsync(long id, Guid user);
    }
}
