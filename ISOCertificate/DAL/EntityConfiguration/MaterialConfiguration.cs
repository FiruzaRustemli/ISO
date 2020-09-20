using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.MaterialCategoryId).IsRequired();
            builder.Property(p => p.MaterialReleasedId).IsRequired();
            builder.Property(p => p.QuantityReleased).IsRequired().HasColumnType("float");
            builder.Property(p => p.Duration).IsRequired().HasColumnType("float");
            builder.Property(p => p.Pollution).IsRequired().HasColumnType("float");
            builder.Property(p => p.QuantityRecovered).IsRequired().HasColumnType("float");

            builder.HasOne(p => p.Investigate)
              .WithMany(p => p.Materials)
              .HasForeignKey(p => p.InvestigateId);

            builder.HasOne(p => p.MaterialCategory)
              .WithMany(p => p.Materials)
              .HasForeignKey(p => p.MaterialCategoryId);

            builder.HasOne(p => p.MaterialReleased)
              .WithMany(p => p.Materials)
              .HasForeignKey(p => p.MaterialReleasedId);


        }
    }
}
