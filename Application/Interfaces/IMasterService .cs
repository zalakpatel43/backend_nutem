using Domain.ViewModels;
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
        // Add additional methods related to MastersEntity if needed
    }
}
