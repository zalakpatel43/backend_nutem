using Application.Helper;
using Application.Interfaces;
using Application.Services;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalletPackingController : ControllerBase
    {
        private readonly IPalletPackingService _palletPackingService;

        public PalletPackingController(IPalletPackingService palletPackingService)
        {
            _palletPackingService = palletPackingService;
        }

        [Route("AddPalletPacking")]
        [HttpPost]
        public async Task<IActionResult> AddPalletPacking(PalletPackingAddEdit model)
        {
            var response = await _palletPackingService.AddPalletPackingAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditPalletPacking")]
        [HttpPost]
        public async Task<IActionResult> EditPalletPacking(PalletPackingAddEdit model)
        {
            var response = await _palletPackingService.UpdatePalletPackingAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllPalletPacking")]
        public async Task<IActionResult> GetAll()
        {
            var data = _palletPackingService.GetAllPalletPackingAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var data = await _palletPackingService.GetPalletPackingByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpGet("DeletePalletPacking")]
        public async Task<IActionResult> Delete(long id)
        {
            long userId = User.Identity.GetUserId();

            await _palletPackingService.DeletePalletPackingAsync(id, userId);
            return NoContent();
        }
    }
}
