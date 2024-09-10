using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyMasterController : ControllerBase
    {
        private readonly ICompanyMasterService _CompanyMasterService;

        public CompanyMasterController(ICompanyMasterService companyMasterService)
        {
            _CompanyMasterService = companyMasterService;
        }

        [HttpGet("GetAllCompany")]
        public async Task<IActionResult> GetAllCompany()
        {
            var data = _CompanyMasterService.GetAllCompanyMasterAsync();
            return Ok(data);
        }
    }
}
