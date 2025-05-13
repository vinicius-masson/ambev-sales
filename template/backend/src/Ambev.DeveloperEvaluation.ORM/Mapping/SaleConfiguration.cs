using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.Number).IsRequired();

            builder.Property(s => s.SaleDate).IsRequired();

            builder.Property(s => s.Customer).IsRequired().HasMaxLength(30);

            builder.Property(s => s.Branch).IsRequired().HasMaxLength(30);

            builder.Property(s => s.TotalSaleAmount).HasColumnType("decimal(18,2)");

            builder.Property(s => s.Status).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.HasMany(s => s.Products)
                .WithOne()
                .HasForeignKey("SaleId")
                .IsRequired(true);

        }
    }
}
