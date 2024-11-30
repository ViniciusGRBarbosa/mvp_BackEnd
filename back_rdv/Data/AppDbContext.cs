using Microsoft.EntityFrameworkCore;

namespace back_rdv.Data;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DATABASE"));
    }
    public required DbSet<Users> Users { get; set; }
    public required DbSet<Address> Addresses { get; set; }
    public required DbSet<HasAddress> HasAddresses { get; set; }
    public required DbSet<Restaurant> Restaurant { get; set; }
    public required DbSet<Product> Product { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HasAddress>()
            .HasKey(ha => new { ha.UserId, ha.AddressId });

        modelBuilder.Entity<HasAddress>()
            .HasOne(ha => ha.User)
            .WithMany(u => u.HasAddresses)
            .HasForeignKey(ha => ha.UserId);

        modelBuilder.Entity<HasAddress>()
            .HasOne(ha => ha.Address)
            .WithMany(a => a.HasAddresses)
            .HasForeignKey(ha => ha.AddressId);
              
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Restaurant) 
            .WithMany(r => r.Products) 
            .HasForeignKey(p => p.RestaurantId) 
            .OnDelete(DeleteBehavior.Cascade); 

    }

}