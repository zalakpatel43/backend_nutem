using Application.Helper;
using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PreCheckListController : ControllerBase
    {
        private readonly IPreCheckListService _preCheckListService;

        public PreCheckListController(IPreCheckListService preCheckListService)
        {
            _preCheckListService = preCheckListService;
        }

        [Route("AddPreCheckList")]
        [HttpPost]
        public async Task<IActionResult> AddPreCheckList(PreCheckListAddEdit model)
        {
            var response = await _preCheckListService.AddPreCheckListAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditPreCheckList")]
        [HttpPost]
        public async Task<IActionResult> EditPreCheckList(PreCheckListAddEdit model)
        {
            var response = await _preCheckListService.UpdatePreCheckListAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllPreCheckList")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _preCheckListService.GetAllPreCheckListAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var data = await _preCheckListService.GetPreCheckListByIdAsync(id);
            if (data == null)
                return BadRequest("PreCheckList not found");
            return Ok(data);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            long userId = User.Identity.GetUserId();

            await _preCheckListService.DeletePreCheckListAsync(id, userId);
            return NoContent();
        }
    }
}
