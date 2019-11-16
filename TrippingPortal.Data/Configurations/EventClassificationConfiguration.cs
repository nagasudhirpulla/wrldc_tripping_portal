using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data.Configurations
{
    public class EventClassificationConfiguration : IEntityTypeConfiguration<EventClassification>
    {
        public void Configure(EntityTypeBuilder<EventClassification> builder)
        {
            // EventClassification name is unique
            builder
            .HasIndex(ec => ec.Name)
            .IsUnique();
        }
    }
}
