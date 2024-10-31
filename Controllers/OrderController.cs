using System.Collections.Generic;
using System.Linq;
using DapperTask.DTOs;
using DapperTask.Models;
using DapperTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service) : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] IEnumerable<int> ids) =>
        Ok(service.Get(ids));

    [HttpPost]
    public IActionResult Insert([FromBody] IEnumerable<Order> orders) =>
        service.Insert(orders) > 0 ? Created() : BadRequest();

    [HttpPut]
    public IActionResult Update([FromBody] IEnumerable<Order> orders) =>
        service.Update(orders) > 0 ? Created() : BadRequest();

    [HttpDelete]
    public IActionResult Delete([FromQuery] IEnumerable<int> ids)
    {
        if (ids.Any(id => id <= 0))
            return NotFound();

        return service.Delete(ids) > 0 ? NoContent() : NotFound();
    }
}
