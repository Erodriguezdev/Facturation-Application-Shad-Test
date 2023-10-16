using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Facturation;

namespace Data.Configuration.Mapping.Facturation
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices", Schema.Facturation)
                .HasKey(x => x.Id);
        }
    }
}