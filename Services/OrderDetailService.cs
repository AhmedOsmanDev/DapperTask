using System.Collections.Generic;
using DapperTask.Models;
using DapperTask.Repositories;

namespace DapperTask.Services;

public class OrderDetailService(OrderDetailRepository repository) : IOrderDetailService
{
    public int Insert(IEnumerable<OrderDetail> orders) =>
        repository.Insert(orders);

    public int Update(IEnumerable<OrderDetail> orders) =>
        repository.Update(orders);
}
