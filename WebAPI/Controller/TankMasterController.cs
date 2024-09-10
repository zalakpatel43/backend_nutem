using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TankMasterController : ControllerBase
    {
        private readonly ITankMasterService _tankMasterService;

        public TankMasterController(ITankMasterService TankMasterService)
        {
            _tankMasterService = TankMasterService;
        }

        [HttpGet("GetAllTankMaster")]
        public async Task<IActionResult> GetAllTankMaster()
        {
            var data = _tankMasterService.GetAllTankMasterAsync();
            return Ok(data);
        }
    }
}
