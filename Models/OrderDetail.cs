using System;
using System.ComponentModel.DataAnnotations;

namespace DapperTask.Models;

public class OrderDetail
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public int Quantity { get; set; }

    public double Price { get; set; }
    public double TotalPrice { get; set; }

    public DateTime? InsertDate { get; set; }

    public int OrderId { get; set; }
}
