using Application.Helper;
using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeCheckController : ControllerBase
    {
        private readonly IAttributeCheckService _attributeCheckService;

        public AttributeCheckController(IAttributeCheckService attributeCheckService)
        {
            _attributeCheckService = attributeCheckService;
        }

        [Route("AddAttributeCheck")]
        [HttpPost]
        public async Task<IActionResult> AddAttributeCheck(AttributeCheckAddEdit model)
        {
            var response = await _attributeCheckService.AddAttributeCheckAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditAttributeCheck")]
        [HttpPost]
        public async Task<IActionResult> EditAttributeCheck(AttributeCheckAddEdit model)
        {
            var response = await _attributeCheckService.UpdateAttributeCheckAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllAttributeCheck")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _attributeCheckService.GetAllAttributeCheckAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _attributeCheckService.GetAttributeCheckByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            long userId = User.Identity.GetUserId();

            await _attributeCheckService.DeleteAttributeCheckAsync(id, userId);
            return NoContent();
        }
    }
}
