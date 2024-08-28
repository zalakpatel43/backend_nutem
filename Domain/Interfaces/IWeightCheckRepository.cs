using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
  
    public interface IWeightCheckRepository : IGenericRepository<WeightCheck>
    {
       
        IQueryable<WeightCheck> GetAllWeightChecksWithProduct();

        Task<WeightCheck> GetByIdAsync(long id);
    }
}
