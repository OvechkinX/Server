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
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Gets All Rows From Order Table
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return new JsonResult(orders);
        }

        // Gets Single Rows From Joined Table by Order ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var orders = await _orderService.GetOrderForwarderAsync(id);
            return new JsonResult(orders);
        }

        // Gets All Rows From Joined Table for current forwarder
        [HttpGet("all/{id}")]
        public async Task<IActionResult> GetAllOrder(Guid id)
        {
            var orders = await _orderService.GetAllOrderForwarder(id);
            return new JsonResult(orders);
        }

        // Gets All Rows From Joined Table for current Transport
        [HttpGet("transport/all/{id}")]
        public async Task<IActionResult> GetAllOrderTransport(Guid id)
        {
            var orders = await _orderService.GetAllOrderTransport(id);
            return new JsonResult(orders);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            await _orderService.AddAsync(order);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(Guid id)
        {
            await _orderService.DeleteAync(id);
            return NoContent();
        }

        [HttpPost("update")]
        public async Task<ActionResult<Vehicle>> Update(Order order)
        {
            await _orderService.UpdateAsync(order);
            return NoContent();
        }

    }
}