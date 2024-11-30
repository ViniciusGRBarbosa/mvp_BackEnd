namespace back_rdv.Data;

public class Restaurant
{
    public long  Id { get; set; }
    public string Name { get; set; }= null!;
    public string?  Description { get; set; }
    public string Type { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}