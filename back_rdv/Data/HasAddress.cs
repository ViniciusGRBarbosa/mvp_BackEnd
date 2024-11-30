namespace back_rdv.Data;

public class HasAddress
{
    public long  UserId { get; set; }
    public Users User { get; set; } = null!;

    public long  AddressId { get; set; }
    public Address Address { get; set; } = null!;
}