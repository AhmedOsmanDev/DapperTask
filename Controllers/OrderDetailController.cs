using System.Collections.Generic;
using DapperTask.Models;
using DapperTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController(IOrderDetailService service) : ControllerBase
{
    [HttpPost]
    public IActionResult Insert([FromBody] IEnumerable<OrderDetail> orderDetails) =>
        service.Insert(orderDetails) > 0 ? Created() : BadRequest();

    [HttpPut]
    public IActionResult Update([FromBody] IEnumerable<OrderDetail> orderDetails) =>
        service.Update(orderDetails) > 0 ? Created() : BadRequest();
}
