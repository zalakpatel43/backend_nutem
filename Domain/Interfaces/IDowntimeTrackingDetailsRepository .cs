using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDowntimeTrackingDetailsRepository : IGenericRepository<DowntimeTrackingDetails>
    {
        // Add methods specific to DowntimeTrackingDetails if needed
        Task UpdateAsync(DowntimeTrackingDetails entity);
    }
}
