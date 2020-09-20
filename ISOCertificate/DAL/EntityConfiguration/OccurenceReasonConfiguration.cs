using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class OccurenceReasonConfiguration : IEntityTypeConfiguration<OccurenceReason>
    {
        public void Configure(EntityTypeBuilder<OccurenceReason> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
