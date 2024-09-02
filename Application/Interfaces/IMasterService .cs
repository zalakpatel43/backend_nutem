using Domain.ViewModels;
using Skyward.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMastersService
    {
        IQueryable<MastersList> GetAllMastersAsync();
        Task<IEnumerable<MastersEntity>> GetVehicleTypeCategoriesAsync();
    }
}
