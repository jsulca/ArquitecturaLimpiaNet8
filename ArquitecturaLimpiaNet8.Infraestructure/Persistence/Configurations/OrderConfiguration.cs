using ArquitecturaLimpiaNet8.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArquitecturaLimpiaNet8.Infraestructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order").HasKey(x => x.Id).HasName("pk_order");

        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.Code).HasColumnName("code");
        builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.Year).HasColumnName("year");
        builder.Property(x => x.Month).HasColumnName("month");
        builder.Property(x => x.IsDeleted).HasColumnName("isdeleted");
        builder.Property(x => x.Total).HasColumnName("total");
    }
}
