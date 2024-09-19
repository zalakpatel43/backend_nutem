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
    public class LiquidPreparationController : ControllerBase
    {
        private readonly ILiquidPreparationService _liquidPreparationService;

        public LiquidPreparationController(ILiquidPreparationService liquidPreparationService)
        {
            _liquidPreparationService = liquidPreparationService;
        }

        [Route("AddLiquidPreparation")]
        [HttpPost]
        public async Task<IActionResult> AddLiquidPreparation(LiquidPreparationAddEdit model)
        {
            var response = await _liquidPreparationService.AddLiquidPreparationAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditLiquidPreparation")]
        [HttpPost]
        public async Task<IActionResult> EditLiquidPreparation(LiquidPreparationAddEdit model)
        {
            var response = await _liquidPreparationService.UpdateLiquidPreparationAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllLiquidPreparation")]
        public async Task<IActionResult> GetAll()
        {
            var data = _liquidPreparationService.GetAllLiquidPreparationAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _liquidPreparationService.GetLiquidPreparationByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpGet("DeleteLiquidPreparation")]
        public async Task<IActionResult> Delete(long Id)
        {
            long userId = User.Identity.GetUserId();

            await _liquidPreparationService.DeletLiquidPreparationAsync(Id, userId);
            return NoContent();
        }
    }
}
