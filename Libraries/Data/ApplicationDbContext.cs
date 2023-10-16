
using Data.Configuration.Mapping.Facturation;
using Microsoft.EntityFrameworkCore;
using Models.Facturation;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
   

    //Facturation

    public DbSet<Customers> Customers { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        // Facturation
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new CustomerTypesMap());
        modelBuilder.ApplyConfiguration(new InvoiceMap());
        modelBuilder.ApplyConfiguration(new InvoiceDetailsMap());        
    }
}
