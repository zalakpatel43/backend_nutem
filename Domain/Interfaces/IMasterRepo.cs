using Domain.Entities;
using Skyward.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMastersRepository : IGenericRepository<MastersEntity>
    {
        Task<IEnumerable<MastersEntity>> GetByCategoryNameAsync(string categoryName);
    }
}
