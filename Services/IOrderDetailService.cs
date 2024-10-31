using System.Collections.Generic;
using DapperTask.Models;

namespace DapperTask.Services;

public interface IOrderDetailService
{
    int Insert(IEnumerable<OrderDetail> orders);
    int Update(IEnumerable<OrderDetail> orders);
}
