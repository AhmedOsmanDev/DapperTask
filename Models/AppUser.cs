using System;
using System.ComponentModel.DataAnnotations;

namespace DapperTask.Models;

public class AppUser
{
    [Key]
    public Guid Id { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Name { get; set; }
    public string Address { get; set; }
}
