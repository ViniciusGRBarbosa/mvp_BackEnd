using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_rdv.Data;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long  Id { get; set; }
    public string Name { get; set; }= null!;
    public string?  Description { get; set; }
    public double Value { get; set; } 
    public long  RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
}