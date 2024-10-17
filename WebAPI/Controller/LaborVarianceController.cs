using Application.Helper;
using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaborVarianceController : ControllerBase
    {
        private readonly ILaborVarianceService _laborVarianceService;

        public LaborVarianceController(ILaborVarianceService laborVarianceService)
        {
            _laborVarianceService = laborVarianceService;
        }

        [Route("AddLaborVariance")]
        [HttpPost]
        public async Task<IActionResult> AddLaborVariance(LaborVarianceAddEdit model)
        {
            var response = await _laborVarianceService.AddLaborVarianceAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditLaborVariance")]
        [HttpPost]
        public async Task<IActionResult> EditLaborVariance(LaborVarianceAddEdit model)
        {
            var response = await _laborVarianceService.UpdateLaborVarianceAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllLaborVariance")]
        public async Task<IActionResult> GetAll()
        {
            var data = _laborVarianceService.GetAllLaborVarianceAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _laborVarianceService.GetLaborVarianceByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpGet("DeleteLaborVariance")]
        public async Task<IActionResult> Delete(long Id)
        {
            long userId = User.Identity.GetUserId();

            await _laborVarianceService.DeleteLaborVarianceAsync(Id, userId);
            return NoContent();
        }
    }
}
