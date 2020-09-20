using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class BodilyLocationTypeConfiguration : IEntityTypeConfiguration<BodilyLocationType>
    {
        public void Configure(EntityTypeBuilder<BodilyLocationType> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
