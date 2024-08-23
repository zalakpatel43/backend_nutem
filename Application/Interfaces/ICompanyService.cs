using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ViewModels;

namespace Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyList>> GetAllCompaniesAsync();
        Task<CompanyAddEdit> GetCompanyByIdAsync(long id);
        Task AddCompanyAsync(CompanyAddEdit model);
        Task UpdateCompanyAsync(CompanyAddEdit model);
        Task DeleteCompanyAsync(long id);
    }
}
