using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftMasterController : ControllerBase
    {
        private readonly IShiftMasterService _shiftMasterService;

        public ShiftMasterController(IShiftMasterService shiftMasterService)
        {
            _shiftMasterService = shiftMasterService;
        }

        [HttpGet("GetAllShift")]
        public async Task<IActionResult> GetAllShift()
        {
            var data = _shiftMasterService.GetAllShiftMasterAsync();
            return Ok(data);
        }
    }
}
