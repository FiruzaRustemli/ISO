﻿using ISOCertificate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ISOCertificate.DAL.EntityConfiguration
{
    internal class InjuryTypeConfiguration : IEntityTypeConfiguration<InjuryType>
    {
        public void Configure(EntityTypeBuilder<InjuryType> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
