using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data.Configurations
{
    public class UtilityOwnerConfiguration : IEntityTypeConfiguration<UtilityOwner>
    {
        public void Configure(EntityTypeBuilder<UtilityOwner> builder)
        {
            // Many to Many relationship of Utility owners
            builder.HasKey(uo => new { uo.UtilityId, uo.OwnerId });
            builder
                .HasOne(uo => uo.Utility)
                .WithMany()
                .HasForeignKey(uo => uo.UtilityId);
            builder
                .HasOne(uo => uo.Owner)
                .WithMany()
                .HasForeignKey(uo => uo.OwnerId);
        }
    }
}
