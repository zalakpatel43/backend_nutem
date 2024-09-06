using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialMasterController : ControllerBase
    {
        private readonly IMaterialMasterService _MaterialMasterService;

        public MaterialMasterController(IMaterialMasterService MaterialMasterService)
        {
            _MaterialMasterService = MaterialMasterService;
        }

        [HttpGet("GetAllMaterialMaster")]
        public async Task<IActionResult> GetAllMaterialMaster()
        {
            var data = _MaterialMasterService.GetAllMaterialMasterAsync();
            return Ok(data);
        }
    }
}
