using Application.Helper;
using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // [HttpGet]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CompanyList>>> GetCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyAddEdit>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddCompany(CompanyAddEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long user = User.Identity.GetUserId();
            await _companyService.AddCompanyAsync(model);
            return CreatedAtAction(nameof(GetCompany), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompany(int id, CompanyAddEdit model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _companyService.UpdateCompanyAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
