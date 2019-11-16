using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data.Configurations
{
    public class EventELConfiguration : IEntityTypeConfiguration<EventEL>
    {
        public void Configure(EntityTypeBuilder<EventEL> builder)
        {
            // Default value of EventEL CreatedAt
            builder
                .Property(e => e.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            // Default value of EventEL UpdatedAt and auto update modify
            builder
                .Property(e => e.UpdatedAt)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
