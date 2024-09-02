﻿using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        private readonly IMastersService _mastersService;

        public MastersController(IMastersService mastersService)
        {
            _mastersService = mastersService;
        }

        [HttpGet("GetAllMasters")]
        public async Task<IActionResult> GetAllMasters()
        {
            var data = _mastersService.GetAllMastersAsync();
            return Ok(data);
        }
    }
}