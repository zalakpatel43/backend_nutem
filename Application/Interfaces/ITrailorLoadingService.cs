using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITrailerLoadingService
    {
        IQueryable<TrailerLoadingList> GetAllTrailerLoadingsAsync();
        Task<TrailerLoadingAddEdit> GetTrailerLoadingByIdAsync(long id);
        Task<long> AddTrailerLoadingAsync(TrailerLoadingAddEdit model, long user);
        Task<long> UpdateTrailerLoadingAsync(TrailerLoadingAddEdit model, long user);
        Task DeleteTrailerLoadingAsync(long id, long user);
    }
}
