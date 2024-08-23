using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        private readonly IProductMasterService _productMasterService;

        public ProductMasterController(IProductMasterService productMasterService)
        {
            _productMasterService = productMasterService;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var data = _productMasterService.GetAllProductMasterAsync();
            return Ok(data);
        }
    }
}
