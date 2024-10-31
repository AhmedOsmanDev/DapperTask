using System.Collections.Generic;
using DapperTask.DTOs;
using DapperTask.Models;

namespace DapperTask.Services;

public interface IOrderService
{
    OrdersAndOrderDetails Get(IEnumerable<int> ids);
    int Insert(IEnumerable<Order> orders);
    int Update(IEnumerable<Order> orders);
    int Delete(IEnumerable<int> ids);
}
