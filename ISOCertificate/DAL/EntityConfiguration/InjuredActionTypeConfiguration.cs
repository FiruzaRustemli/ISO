using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class InjuredActionTypeConfiguration : IEntityTypeConfiguration<InjuredActionType>
    {
        public void Configure(EntityTypeBuilder<InjuredActionType> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
