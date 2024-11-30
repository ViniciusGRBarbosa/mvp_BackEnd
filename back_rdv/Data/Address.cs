using System.ComponentModel.DataAnnotations;

namespace back_rdv.Data;

public class Address
{
    public long  Id { get; set; }
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string? Complement { get; set; }
    public string District { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Uf { get; set; } = null!;
    public string ZipCode { get; set; } = null!;

    
    public ICollection<HasAddress> HasAddresses { get; set; } = new List<HasAddress>();
}