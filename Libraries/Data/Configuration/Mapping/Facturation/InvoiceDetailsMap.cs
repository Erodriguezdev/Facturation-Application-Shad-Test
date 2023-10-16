using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Facturation;

namespace Data.Configuration.Mapping.Facturation
{
    public class InvoiceDetailsMap : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("InvoiceDetails", Schema.Facturation)
                .HasKey(x => x.Id);
        }
    }
}