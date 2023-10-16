using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Facturation;

namespace Data.Configuration.Mapping.Facturation
{
    public class CustomerTypesMap : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.ToTable("CustomerTypes", Schema.Facturation)
                .HasKey(x => x.Id);
        }
    }
}