using CleanNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanNet.Infra.Data.EntitiesConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Amount).HasPrecision(10, 2);
        builder.Property(p => p.Comission).HasPrecision(10, 2);
        builder.HasOne(e => e.Seller).WithMany(e => e.Orders)
            .HasForeignKey(e => e.SellerId);
    }
}
