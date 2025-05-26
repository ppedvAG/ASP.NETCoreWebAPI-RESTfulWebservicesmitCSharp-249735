using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel.Models;

[PrimaryKey(nameof(Id))]
public class Customer
{
    [Key, Column("CustomerId")]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
}
