using System.Collections.Generic;
using DapperTask.DTOs;
using DapperTask.Models;
using DapperTask.Repositories;

namespace DapperTask.Services;

public class OrderService(OrderRepository repository) : IOrderService
{
    public OrdersAndOrderDetails Get(IEnumerable<int> ids) =>
        repository.Get(ids);

    public int Insert(IEnumerable<Order> orders) =>
        repository.Insert(orders);

    public int Update(IEnumerable<Order> orders) =>
        repository.Update(orders);

    public int Delete(IEnumerable<int> ids) =>
        repository.Delete(ids);
}
