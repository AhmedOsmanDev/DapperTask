using System;
using System.ComponentModel.DataAnnotations;

namespace DapperTask.Models;

public class Order
{
    public int Id { get; set; }
    public Guid UserId { get; set; }

    public double TotalPrice { get; set; }
    public int ItemCount { get; set; }

    public DateTime? InsertDate { get; set; }
}
