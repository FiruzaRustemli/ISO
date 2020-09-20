using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class InvestigateLineConfiguration : IEntityTypeConfiguration<InvestigateLine>
    {
        public void Configure(EntityTypeBuilder<InvestigateLine> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.InvestigateId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Position).IsRequired();
            builder.Property(p => p.Organization).IsRequired();
            builder.Property(p => p.LineTypeId).IsRequired();

            builder.HasOne(p => p.Investigate)
               .WithMany(p => p.InvestigateLines)
               .HasForeignKey(p => p.InvestigateId);

            builder.HasOne(p => p.LineType)
             .WithMany(p => p.InvestigateLines)
             .HasForeignKey(p => p.LineTypeId);

        }
    }
}
