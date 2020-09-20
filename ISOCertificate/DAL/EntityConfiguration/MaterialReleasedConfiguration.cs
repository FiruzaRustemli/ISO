using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class MaterialReleasedConfiguration : IEntityTypeConfiguration<MaterialReleased>
    {
        public void Configure(EntityTypeBuilder<MaterialReleased> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
