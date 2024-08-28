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
        // Add methods specific to MastersEntity if needed
    }
}
