using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauseMasterController : ControllerBase
    {
        private readonly ICauseMasterService _causeMasterService;

        public CauseMasterController(ICauseMasterService causeMasterService)
        {
            _causeMasterService = causeMasterService;
        }

        [HttpGet("GetAllCauses")]
        public async Task<IActionResult> GetAllCauses()
        {
            var data =  _causeMasterService.GetAllCauseMastersAsync();
            return Ok(data);
        }
    }
}
