using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class InvestigateConfiguration : IEntityTypeConfiguration<Investigate>
    {
        public void Configure(EntityTypeBuilder<Investigate> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Position).IsRequired();
            builder.Property(p => p.DateTime).IsRequired();
            builder.Property(p => p.Area).IsRequired();
            builder.Property(p => p.Activity).IsRequired();
            builder.Property(p => p.OccurenceReasonId).IsRequired();
            builder.Property(p => p.OccurenceTypeId).IsRequired();
            builder.Property(p => p.WheatherTypeId).IsRequired();
            builder.Property(p => p.GroundTypeId).IsRequired();
            builder.Property(p => p.GroundConditionTypeId).IsRequired();
            builder.Property(p => p.IlluminationTypeId).IsRequired();
            builder.Property(p => p.ContactTypeId).IsRequired();
            builder.Property(p => p.InjuryTypeId).IsRequired();
            builder.Property(p => p.IlnessTypeId).IsRequired();
            builder.Property(p => p.BodilyLocationTypeId).IsRequired();
            builder.Property(p => p.InjuredActionTypeId).IsRequired();
            builder.Property(p => p.ReleaseTypeId).IsRequired();
            builder.Property(p => p.ReleasedToTypeId).IsRequired();
            builder.Property(p => p.DescriptionIncident).IsRequired();
            builder.Property(p => p.DescriptionImmediate).IsRequired();

            builder.HasOne(p => p.OccurenceReason)
                .WithMany(p => p.Investigates)
                .HasForeignKey(p => p.OccurenceReasonId);

            builder.HasOne(p => p.OccurenceType)
                .WithMany(p => p.Investigates)
                .HasForeignKey(p => p.OccurenceTypeId);

            builder.HasOne(p => p.WheatherType)
                .WithMany(p => p.Investigates)
                .HasForeignKey(p => p.WheatherTypeId);

            builder.HasOne(p => p.GroundType)
                 .WithMany(p => p.Investigates)
                 .HasForeignKey(p => p.GroundTypeId);

            builder.HasOne(p => p.GroundConditionType)
                 .WithMany(p => p.Investigates)
                 .HasForeignKey(p => p.GroundConditionTypeId);

            builder.HasOne(p => p.IlluminationType)
                .WithMany(p => p.Investigates)
                .HasForeignKey(p => p.IlluminationTypeId);

            builder.HasOne(p => p.ContactType)
                .WithMany(p => p.Investigates)
                .HasForeignKey(p => p.ContactTypeId);

            builder.HasOne(p => p.InjuryType)
                .WithMany(p => p.Investigates)
                .HasForeignKey(p => p.InjuryTypeId);

            builder.HasOne(p => p.IlnessType)
                .WithMany(p => p.Investigates)
                .HasForeignKey(p => p.IlnessTypeId);

            builder.HasOne(p => p.BodilyLocationType)
               .WithMany(p => p.Investigates)
               .HasForeignKey(p => p.BodilyLocationTypeId);

            builder.HasOne(p => p.InjuredActionType)
               .WithMany(p => p.Investigates)
               .HasForeignKey(p => p.InjuredActionTypeId);

            builder.HasOne(p => p.ReleaseType)
               .WithMany(p => p.Investigates)
               .HasForeignKey(p => p.ReleaseTypeId);

            builder.HasOne(p => p.ReleasedToType)
               .WithMany(p => p.Investigates)
               .HasForeignKey(p => p.ReleasedToTypeId);

            //builder.HasOne(p => p.UnSafeFactType)
            //   .WithMany(p => p.Investigates)
            //   .HasForeignKey(p => p.UnSafeFactTypeId);

            //builder.HasOne(p => p.UnSafeConditionType)
            //  .WithMany(p => p.Investigates)
            //  .HasForeignKey(p => p.UnSafeConditionTypeId);

        }
    }
}
