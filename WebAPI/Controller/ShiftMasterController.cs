using Application.Helper;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
          //  var userIdClaim = User.FindFirst(IdentityHelper.CustomClaimTypes.UserId).Value;
           // var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var data = _shiftMasterService.GetAllShiftMasterAsync();
            return Ok(data);
        }
    }
}
