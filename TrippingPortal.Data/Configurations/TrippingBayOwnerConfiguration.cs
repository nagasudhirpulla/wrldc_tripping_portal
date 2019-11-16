using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data.Configurations
{
    public class TrippingBayOwnerConfiguration : IEntityTypeConfiguration<TrippingBayOwner>
    {
        public void Configure(EntityTypeBuilder<TrippingBayOwner> builder)
        {
            // Many to Many relationship of Trippings and Bay Owners
            builder.HasKey(tbo => new { tbo.TrippingId, tbo.OwnerId });
            builder
                .HasOne(tbo => tbo.Tripping)
                .WithMany()
                .HasForeignKey(tbo => tbo.TrippingId);
            builder
                .HasOne(tbo => tbo.Owner)
                .WithMany()
                .HasForeignKey(tbo => tbo.OwnerId);
        }
    }
}
