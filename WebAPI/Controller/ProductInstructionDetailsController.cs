using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInstructionDetailsController : ControllerBase
    {
        private readonly IProductInstructionDetailsService _ProductInstructionDetailsService;

        public ProductInstructionDetailsController(IProductInstructionDetailsService ProductInstructionDetailsService)
        {
            _ProductInstructionDetailsService = ProductInstructionDetailsService;
        }

        [HttpGet("GetAllProductInstructionDetails")]
        public async Task<IActionResult> GetAllProductInstructionDetails()
        {
            var data = _ProductInstructionDetailsService.GetAllProductInstructionAsync();
            return Ok(data);
        }
    }
}
