using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class IlnessTypeConfiguration : IEntityTypeConfiguration<IlnessType>
    {
        public void Configure(EntityTypeBuilder<IlnessType> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
