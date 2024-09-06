using Application.Helper;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartEndBatchChecklistController : ControllerBase
    {
        private readonly IStartEndBatchChecklistService _startEndBatchChecklistService;

        public StartEndBatchChecklistController(IStartEndBatchChecklistService StartEndBatchChecklistService)
        {
            _startEndBatchChecklistService = StartEndBatchChecklistService;
        }

        [HttpGet("GetAllStartEndBatchChecklist")]
        public async Task<IActionResult> GetAllStartEndBatchChecklist()
        {
            var data = _startEndBatchChecklistService.GetAllStartEndBatchChecklistAsync();
            return Ok(data);
        }
    }
}
