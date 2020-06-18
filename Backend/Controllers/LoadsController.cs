using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadsController : ControllerBase
    {

        private readonly ILoadService _loadService;

        public LoadsController(ILoadService loadService)
        {
            _loadService = loadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loads = await _loadService.GetAllAsync();
            return new JsonResult(loads);
        }

        // Getting current user loads
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var load = await _loadService.GetAsync(id);
            return new JsonResult(load);
        }

        [HttpPost]
        public async Task<ActionResult<Load>> Post(Load load)
        {
            await _loadService.AddAsync(load);
            return Ok(load);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Load>> Delete(Guid id)
        {
            await _loadService.DeleteAync(id);
            return NoContent();
        }

        
        [HttpPost("update")]
        public async Task<ActionResult<Load>> Update(Load load)
        {
            await _loadService.UpdateAsync(load);
            return NoContent();
        }
        

    }
}