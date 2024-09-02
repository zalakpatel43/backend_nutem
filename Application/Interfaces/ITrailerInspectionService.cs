using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITrailerInspectionService
    {
        IQueryable<TrailerInspectionList> GetAllTrailerInspectionAsync();
        Task<TrailerInspectionAddEdit> GetTrailerInspectionByIdAsync(long id);
        Task<long> AddTrailerInspectionAsync(TrailerInspectionAddEdit model, long user);
        Task<long> UpdateTrailerInspectionAsync(TrailerInspectionAddEdit model, long user);
        Task DeleteTrailerInspectionAsync(long id, long user);
    }
}
