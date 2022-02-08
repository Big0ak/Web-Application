using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_lab.Models;
using Web_lab.Services;

namespace Web_lab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listOrder = _orderService.GetAll();
            return Ok(listOrder);
        }

        [HttpGet]
        public IActionResult GetById(Guid id = default)
        {
            if (id == Guid.Empty) return BadRequest();
            var Order = _orderService.GetById(id);
            return Ok(Order);
        }

        [HttpPost]
        public IActionResult Save(Order order)
        {
            var isSuccess = _orderService.Save(order);
            return Ok(isSuccess);
        }

        [HttpPut]
        public IActionResult Edit(Order order)
        {
            var isSuccess = _orderService.Edit(order);
            return Ok(isSuccess);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var isSuccess = _orderService.Delete(id);
            return Ok(isSuccess);
        }
    }
}
