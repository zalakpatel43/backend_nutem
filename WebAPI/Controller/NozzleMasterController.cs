using Application.Interfaces;
using Application.Services;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NozzleMasterController : ControllerBase
    {
        private readonly INozzleMasterService _nozzleMasterService;

        public NozzleMasterController(INozzleMasterService nozzleMasterService)
        {
            _nozzleMasterService = nozzleMasterService;
        }

        [HttpGet("GetAllNozzle")]
        public async Task<IActionResult> GetAllNozzle([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var paginationRequest = new PaginationRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var data = await _nozzleMasterService.GetAllNozzleMasterAsync(paginationRequest);
            return Ok(data);
        }
    }
}
