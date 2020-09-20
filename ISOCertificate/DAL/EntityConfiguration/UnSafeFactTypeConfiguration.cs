using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class UnSafeFactTypeConfiguration : IEntityTypeConfiguration<UnSafeFactType>
    {
        public void Configure(EntityTypeBuilder<UnSafeFactType> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
