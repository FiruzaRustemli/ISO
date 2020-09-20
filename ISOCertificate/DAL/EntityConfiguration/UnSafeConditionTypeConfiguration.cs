using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class UnSafeConditionTypeConfiguration : IEntityTypeConfiguration<UnSafeConditionType>
    {
        public void Configure(EntityTypeBuilder<UnSafeConditionType> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
