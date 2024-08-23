using Application.Interfaces;
using Application.Services;
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
        public async Task<IActionResult> GetAllNozzle()
        {
            var data = _nozzleMasterService.GetAllNozzleMasterAsync();
            return Ok(data);
        }
    }
}
