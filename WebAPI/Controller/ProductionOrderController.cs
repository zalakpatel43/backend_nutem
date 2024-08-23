using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionOrderController : ControllerBase
    {
        private readonly IProductionOrderService _prodcutionOrderService;

        public ProductionOrderController(IProductionOrderService prodcutionOrderService)
        {
            _prodcutionOrderService = prodcutionOrderService;
        }

        [HttpGet("GetAllProductionOrder")]
        public async Task<IActionResult> GetAllProductionOrder()
        {
            var data = _prodcutionOrderService.GetAllProductionOrderAsync();
            return Ok(data);
        }
    }
}
