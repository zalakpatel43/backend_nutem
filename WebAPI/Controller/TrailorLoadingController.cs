using Application.Helper;
using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrailerLoadingController : ControllerBase
    {
        private readonly ITrailerLoadingService _trailerLoadingService;

        public TrailerLoadingController(ITrailerLoadingService trailerLoadingService)
        {
            _trailerLoadingService = trailerLoadingService;
        }

        [Route("AddTrailerLoading")]
        [HttpPost]
        public async Task<IActionResult> AddTrailerLoading(TrailerLoadingAddEdit model)
        {
            var response = await _trailerLoadingService.AddTrailerLoadingAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditTrailerLoading")]
        [HttpPost]
        public async Task<IActionResult> EditTrailerLoading(TrailerLoadingAddEdit model)
        {
            var response = await _trailerLoadingService.UpdateTrailerLoadingAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllTrailerLoadings")]
        public IActionResult GetAll()
        {
            var data = _trailerLoadingService.GetAllTrailerLoadingsAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var data = await _trailerLoadingService.GetTrailerLoadingByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpGet("DeleteTrailerLoading")]
        public async Task<IActionResult> Delete(long id)
        {
            long userId = User.Identity.GetUserId();

            await _trailerLoadingService.DeleteTrailerLoadingAsync(id, userId);
            return NoContent();
        }
    }
}
