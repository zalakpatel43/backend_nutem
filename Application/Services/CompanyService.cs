using Application.Interfaces;
using Domain.Entities;
using Domain.ViewModels;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyList>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            return companies.Select(detailedCompany => new CompanyList
            {
                Id = detailedCompany.Id,
                CompanyName = detailedCompany.CompanyName,
                Alias = detailedCompany.Alias,
                Address1 = detailedCompany.Address1,
                Address2 = detailedCompany.Address2,
                Address3 = detailedCompany.Address3,
                Pincode = detailedCompany.Pincode,
                City = detailedCompany.City,
                State = detailedCompany.State,
                Country = detailedCompany.Country,
                PANNo = detailedCompany.PANNo,
                GSTNo = detailedCompany.GSTNo,
                EmailID = detailedCompany.EmailID,
                Website = detailedCompany.Website,
                IsActive = detailedCompany.IsActive,
                CreatedBy = detailedCompany.CreatedBy,
                CreatedDate = detailedCompany.CreatedDate,
                LastModifiedBy = detailedCompany.LastModifiedBy,
                LastModifiedDate = detailedCompany.LastModifiedDate,
                CompanyLogoId = detailedCompany.CompanyLogoId,
                CurrencyID = detailedCompany.CurrencyID,
                CompanyCode = detailedCompany.CompanyCode,
                StateName = detailedCompany.StateName,
                PhoneNo = detailedCompany.PhoneNo
            });
        }

        public async Task<CompanyAddEdit> GetCompanyByIdAsync(long id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null) return null;

            return new CompanyAddEdit
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Alias = company.Alias,
                Address1 = company.Address1,
                Address2 = company.Address2,
                Address3 = company.Address3,
                Pincode = company.Pincode,
                City = company.City,
                State = company.State,
                Country = company.Country,
                PANNo = company.PANNo,
                GSTNo = company.GSTNo,
                EmailID = company.EmailID,
                Website = company.Website,
                IsActive = company.IsActive,
                CreatedBy = company.CreatedBy,
                CreatedDate = company.CreatedDate,
                LastModifiedBy = company.LastModifiedBy,
                LastModifiedDate = company.LastModifiedDate,
                CompanyLogoId = company.CompanyLogoId,
                CurrencyID = company.CurrencyID,
                CompanyCode = company.CompanyCode,
                StateName = company.StateName,
                PhoneNo = company.PhoneNo
            };
        }

        public async Task AddCompanyAsync(CompanyAddEdit model)
        {
            var company = new Company
            {
                Id = model.Id,
                CompanyName = model.CompanyName,
                Alias = model.Alias,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Address3 = model.Address3,
                Pincode = model.Pincode,
                City = model.City,
                State = model.State,
                Country = model.Country,
                PANNo = model.PANNo,
                GSTNo = model.GSTNo,
                EmailID = model.EmailID,
                Website = model.Website,
                IsActive = model.IsActive,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                LastModifiedBy = model.LastModifiedBy,
                LastModifiedDate = model.LastModifiedDate,
                CompanyLogoId = model.CompanyLogoId,
                CurrencyID = model.CurrencyID,
                CompanyCode = model.CompanyCode,
                StateName = model.StateName,
                PhoneNo = model.PhoneNo
            };

            await _companyRepository.AddAsync(company);
        }

        public async Task UpdateCompanyAsync(CompanyAddEdit model)
        {
            var company = await _companyRepository.GetByIdAsync(model.Id);
            if (company != null)
            {
                company.CompanyName = model.CompanyName;
                company.Alias = model.Alias;
                company.Address1 = model.Address1;
                company.Address2 = model.Address2;
                company.Address3 = model.Address3;
                company.Pincode = model.Pincode;
                company.City = model.City;
                company.State = model.State;
                company.Country = model.Country;
                company.PANNo = model.PANNo;
                company.GSTNo = model.GSTNo;
                company.EmailID = model.EmailID;
                company.Website = model.Website;
                company.IsActive = model.IsActive;
                company.CreatedBy = model.CreatedBy;
                company.CreatedDate = model.CreatedDate;
                company.LastModifiedBy = model.LastModifiedBy;
                company.LastModifiedDate = model.LastModifiedDate;
                company.CompanyLogoId = model.CompanyLogoId;
                company.CurrencyID = model.CurrencyID;
                company.CompanyCode = model.CompanyCode;
                company.StateName = model.StateName;
                company.PhoneNo = model.PhoneNo;

                await _companyRepository.UpdateAsync(company);
            }
        }

        public async Task DeleteCompanyAsync(long id)
        {
            await _companyRepository.DeleteAsync(id);
        }
    }
}
