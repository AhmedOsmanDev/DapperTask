using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperTask.DTOs;
using DapperTask.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperTask.Repositories;

public class OrderRepository(IConfiguration configuration)
{
    private readonly SqlConnection _db = new(configuration.GetConnectionString("DapperTask"));

    public OrdersAndOrderDetails Get(IEnumerable<int> ids)
    {
        var query = ids.Any() ?
            "SELECT * FROM [Order] WHERE [Order].[Id] IN @Ids;" +
            "SELECT * FROM [OrderDetail] WHERE [OrderId] IN @Ids;" :
            "SELECT * FROM [Order];" +
            "SELECT * FROM [OrderDetail];";

        _db.Open();
        var results = _db.QueryMultiple(query, new { Ids = ids });
        var result = new OrdersAndOrderDetails
            { Orders = results.Read<Order>(), OrderDetails = results.Read<OrderDetail>() };
        _db.Close();

        return result;
    }

    public int Insert(IEnumerable<Order> orders)
    {
        const string query =
            "INSERT INTO [Order] ([ItemCount], [InsertDate], [UserId]) VALUES(@ItemCount, @InsertDate, @UserId);";

        _db.Open();
        var result = _db.Execute(query, orders);
        _db.Close();

        return result;
    }

    public int Update(IEnumerable<Order> orders)
    {
        const string query =
            "UPDATE [Order] SET [ItemCount] = @ItemCount, [InsertDate] = @InsertDate, [UserId] = @UserId WHERE [Id] = @Id;";

        _db.Open();
        var result = _db.Execute(query, orders);
        _db.Close();

        return result;
    }

    public int Delete(IEnumerable<int> ids)
    {
        const string query = "DELETE FROM [Order] WHERE [Order].[Id] IN @Ids;";

        _db.Open();
        var result = _db.Execute(query, new { Ids = ids });
        _db.Close();

        return result;
    }
}
