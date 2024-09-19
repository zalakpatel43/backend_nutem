using Application.Helper;
using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrailerInspectionController : ControllerBase
    {
        private readonly ITrailerInspectionService _trailerInspectionService;

        public TrailerInspectionController(ITrailerInspectionService trailerInspectionService)
        {
            _trailerInspectionService = trailerInspectionService;
        }

        [Route("AddTrailerInspection")]
        [HttpPost]
        public async Task<IActionResult> AddTrailerInspection(TrailerInspectionAddEdit model)
        {
            var response = await _trailerInspectionService.AddTrailerInspectionAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditTrailerInspection")]
        [HttpPost]
        public async Task<IActionResult> EditTrailerInspection(TrailerInspectionAddEdit model)
        {
            var response = await _trailerInspectionService.UpdateTrailerInspectionAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllTrailerInspection")]
        public async Task<IActionResult> GetAll()
        {
            var data = _trailerInspectionService.GetAllTrailerInspectionAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _trailerInspectionService.GetTrailerInspectionByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpGet("DeleteTrailerInspection")]
        public async Task<IActionResult> Delete(long Id)
        {
            long userId = User.Identity.GetUserId();

            await _trailerInspectionService.DeleteTrailerInspectionAsync(Id, userId);
            return NoContent();
        }
    }
}
