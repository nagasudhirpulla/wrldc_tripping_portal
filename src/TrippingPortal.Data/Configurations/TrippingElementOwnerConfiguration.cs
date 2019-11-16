using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data.Configurations
{
    public class TrippingElementOwnerConfiguration : IEntityTypeConfiguration<TrippingElementOwner>
    {
        public void Configure(EntityTypeBuilder<TrippingElementOwner> builder)
        {
            // Many to Many relationship of Trippings and Element Owners
            builder.HasKey(teo => new { teo.TrippingId, teo.OwnerId });
            builder
                .HasOne(teo => teo.Tripping)
                .WithMany()
                .HasForeignKey(teo => teo.TrippingId);
            builder
                .HasOne(teo => teo.Owner)
                .WithMany()
                .HasForeignKey(teo => teo.OwnerId);
        }
    }
}
