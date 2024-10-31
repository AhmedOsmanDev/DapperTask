using System.Collections.Generic;
using DapperTask.Models;

namespace DapperTask.DTOs;

public class OrdersAndOrderDetails
{
    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<OrderDetail> OrderDetails { get; set; }
}
