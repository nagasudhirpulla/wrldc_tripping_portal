using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data.Configurations
{
    public class TrippingELConfiguration : IEntityTypeConfiguration<TrippingEL>
    {
        public void Configure(EntityTypeBuilder<TrippingEL> builder)
        {
            // Default value of TrippingEL CreatedAt
            builder
                .Property(tel => tel.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            // Default value of TrippingEL UpdatedAt and auto update modify
            builder
                .Property(tel => tel.UpdatedAt)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
