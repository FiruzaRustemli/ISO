using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.DocumentName).IsRequired();
            builder.Property(p => p.Attachment).IsRequired();

            builder.HasOne(p => p.Investigate)
             .WithMany(p => p.Images)
             .HasForeignKey(p => p.InvestigateId);

            builder.HasOne(p => p.DocumentType)
              .WithMany(p => p.Images)
              .HasForeignKey(p => p.DocumentTypeId);
        }
    }
}
