using Application.Helper;
using Application.Interfaces;
using Application.Services;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightCheckController : ControllerBase
    {
        private readonly IWeightCheckService _weightCheckService;

        public WeightCheckController(IWeightCheckService weightCheckService)
        {
            _weightCheckService = weightCheckService;
        }

        [Route("AddWeighCheck")]
        [HttpPost]
        public async Task<IActionResult> AddWeighCheck(WeightCheckAddEdit model)
        {
            var response = await _weightCheckService.AddWeightCheckAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditWeighCheck")]
        [HttpPost]
        public async Task<IActionResult> EditWeighCheck(WeightCheckAddEdit model)
        {
            var response = await _weightCheckService.UpdateWeightCheckAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllWeightCheck")]
        public async Task<IActionResult> GetAll()
        {
            var data =  _weightCheckService.GetAllWeightCheckAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _weightCheckService.GetWeightCheckByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpGet("DeleteWeightCheck")]
        public async Task<IActionResult> Delete(long Id)
        {
            long userId = User.Identity.GetUserId();

            await _weightCheckService.DeleteWeightCheckAsync(Id, userId);
            return NoContent();
        }
    }
}
