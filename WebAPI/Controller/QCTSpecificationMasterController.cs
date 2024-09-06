using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QCTSpecificationMasterController : ControllerBase
    {
        private readonly IQCTSpecificationMasterService _QCTSpecificationMasterService;

        public QCTSpecificationMasterController(IQCTSpecificationMasterService QCTSpecificationMasterService)
        {
            _QCTSpecificationMasterService = QCTSpecificationMasterService;
        }

        [HttpGet("GetAllQCTSpecificationMaster")]
        public async Task<IActionResult> GetAllQCTSpecificationMaster()
        {
            var data = _QCTSpecificationMasterService.GetAllQCTSpecificationMasterAsync();
            return Ok(data);
        }
    }
}
