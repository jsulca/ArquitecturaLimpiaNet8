using ArquitecturaLimpiaNet8.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArquitecturaLimpiaNet8.Infraestructure.Persistence.Configurations;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.ToTable("orderproduct").HasKey(x => x.Id).HasName("pk_orderproduct");

        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.OrderId).HasColumnName("orderid");
        builder.Property(x => x.ProductId).HasColumnName("productid");

        builder.Property(x => x.Amount).HasColumnName("amount").HasPrecision(20, 2);
        builder.Property(x => x.Price).HasColumnName("price").HasPrecision(20, 2);

        builder.HasOne(x => x.Order).WithMany(x => x.Products).HasConstraintName("fk_orderproduct_order");
    }
}
