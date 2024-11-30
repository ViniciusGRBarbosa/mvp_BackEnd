using System.ComponentModel.DataAnnotations;

namespace back_rdv.Data;

public class Users
{
    public long Id {get; set;}
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string PhoneNumber {get; set;} = null!;
    public string Uf {get; set;} = null!;
     public ICollection<HasAddress> HasAddresses { get; set; } = new List<HasAddress>();
    
}