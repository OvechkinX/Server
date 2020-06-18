using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return new JsonResult(vehicles);
        }

        // Getting current user vehicles
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var vehicles = await _vehicleService.GetAsync(id);
            return new JsonResult(vehicles);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> Post(Vehicle vehicle)
        {
            await _vehicleService.AddAsync(vehicle);
            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> Delete(Guid id)
        {
            await _vehicleService.DeleteAync(id);
            return NoContent();
        }

        [HttpPost("update")]
        public async Task<ActionResult<Vehicle>> Update(Vehicle vehicle)
        {
            await _vehicleService.UpdateAsync(vehicle);
            return NoContent();
        }
    }
}