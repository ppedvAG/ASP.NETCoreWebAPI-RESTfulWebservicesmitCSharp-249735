using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel.Models;

[PrimaryKey(nameof(Id))]
public class Order
{
    [Key, Column("OrderId")]
    public Guid Id { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Guid CustomerId { get; set; }

    public List<Auto> Items { get; set; }
}