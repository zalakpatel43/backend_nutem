using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPalletPackingService
    {
        IQueryable<PalletPackingList> GetAllPalletPackingAsync();
        Task<PalletPackingAddEdit> GetPalletPackingByIdAsync(long id);
        Task<long> AddPalletPackingAsync(PalletPackingAddEdit model, long user);
        Task<long> UpdatePalletPackingAsync(PalletPackingAddEdit model, long user);
        Task DeletePalletPackingAsync(long id, long user);
    }
}
