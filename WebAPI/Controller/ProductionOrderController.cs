using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("GetPOByStatus")]
        public async Task<IActionResult> GetPOByStatus(String status)
        {
            var data = _prodcutionOrderService.GetPOByStatus(status);
            return Ok(data);
        }


        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var data = await _prodcutionOrderService.GetProductionOrderByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPatch("ToggleStatus/{id}")]
        public async Task<IActionResult> ToggleStatus(long id)
        {
            var result = await _prodcutionOrderService.ToggleProductionOrderStatusAsync(id);

            if (!result)
                return NotFound();

            return Ok(new { Message = "Status updated successfully" });
        }
    }
}
