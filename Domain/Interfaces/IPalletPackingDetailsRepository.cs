using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPalletPackingDetailsRepository : IGenericRepository<PalletPackingDetails>
    {
        // Add methods specific to PalletPackingDetails if needed
        Task<IEnumerable<PalletPackingDetails>> GetAllAsync();
    }
}
