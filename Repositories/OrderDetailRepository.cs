using System.Collections.Generic;
using Dapper;
using DapperTask.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperTask.Repositories;

public class OrderDetailRepository(IConfiguration configuration)
{
    private readonly SqlConnection _db = new(configuration.GetConnectionString("DapperTask"));

    public int Insert(IEnumerable<OrderDetail> orderDetails)
    {
        const string query =
            "INSERT INTO [OrderDetail] ([Name], [Quantity], [Price], [InsertDate], [OrderId]) VALUES(@Name, @Quantity, @Price, @InsertDate, @OrderId);";

        _db.Open();
        var result = _db.Execute(query, orderDetails);
        _db.Close();

        return result;
    }

    public int Update(IEnumerable<OrderDetail> orderDetails)
    {
        const string query =
            "UPDATE [OrderDetail] SET [Name] = @Name, [Quantity] = @Quantity, [Price] = @Price, [InsertDate] = @InsertDate, [OrderId] = @OrderId WHERE [Id] = @Id;";

        _db.Open();
        var result = _db.Execute(query, orderDetails);
        _db.Close();

        return result;
    }
}
