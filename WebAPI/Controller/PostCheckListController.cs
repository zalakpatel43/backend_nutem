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
    public class PostCheckListController : ControllerBase
    {
        private readonly IPostCheckListService _postCheckListService;

        public PostCheckListController(IPostCheckListService postCheckListService)
        {
            _postCheckListService = postCheckListService;
        }

        [Route("AddPostCheckList")]
        [HttpPost]
        public async Task<IActionResult> AddPostCheckList(PostCheckListAddEdit model)
        {
            var response = await _postCheckListService.AddPostCheckListAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [Route("EditPostCheckList")]
        [HttpPost]
        public async Task<IActionResult> EditPostCheckList(PostCheckListAddEdit model)
        {
            var response = await _postCheckListService.UpdatePostCheckListAsync(model, User.Identity.GetUserId());
            return Ok(response);
        }

        [HttpGet("GetAllPostCheckList")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _postCheckListService.GetAllPostCheckListAsync();
            return Ok(data);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var data = await _postCheckListService.GetPostCheckListByIdAsync(id);
            if (data == null)
                return BadRequest("PostCheckList not found");
            return Ok(data);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            long userId = User.Identity.GetUserId();

            await _postCheckListService.DeletePostCheckListAsync(id, userId);
            return NoContent();
        }
    }
}
