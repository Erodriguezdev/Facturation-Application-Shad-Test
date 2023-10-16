using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Facturation;

namespace Data.Configuration.Mapping.Facturation
{
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable("Customers", Schema.Facturation)
                .HasKey(x => x.Id);
        }
    }
}