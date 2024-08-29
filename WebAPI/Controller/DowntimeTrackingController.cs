using Application.Helper;
using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DowntimeTrackingController : ControllerBase
    {
        private readonly IDowntimeTrackingService _downtimeTrackingService;

        public DowntimeTrackingController(IDowntimeTrackingService downtimeTrackingService)
        {
            _downtimeTrackingService = downtimeTrackingService;
        }

        [HttpPost("AddDowntimeTracking")]
        public async Task<IActionResult> AddDowntimeTracking([FromBody] DowntimeTrackingAddEdit model)
        {
            var response = await _downtimeTrackingService.AddDowntimeTrackingAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpPost("EditDowntimeTracking")]
        public async Task<IActionResult> EditDowntimeTracking([FromBody] DowntimeTrackingAddEdit model)
        {
            var response = await _downtimeTrackingService.UpdateDowntimeTrackingAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllDowntimeTrackings")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _downtimeTrackingService.GetAllDowntimeTrackingsAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var data = await _downtimeTrackingService.GetDowntimeTrackingByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete("DeleteDowntimeTracking")]
        public async Task<IActionResult> Delete(long id)
        {
            await _downtimeTrackingService.DeleteDowntimeTrackingAsync(id, User.Identity.GetUserId());
            return NoContent();
        }
    }
}
