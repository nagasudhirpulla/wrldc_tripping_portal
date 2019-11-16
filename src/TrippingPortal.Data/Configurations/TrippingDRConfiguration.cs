using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data.Configurations
{
    public class TrippingDRConfiguration : IEntityTypeConfiguration<TrippingDR>
    {
        public void Configure(EntityTypeBuilder<TrippingDR> builder)
        {
            // Default value of TrippingDR CreatedAt
            builder
                .Property(tel => tel.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            // Default value of TrippingDR UpdatedAt and auto update modify
            builder
                .Property(tel => tel.UpdatedAt)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
