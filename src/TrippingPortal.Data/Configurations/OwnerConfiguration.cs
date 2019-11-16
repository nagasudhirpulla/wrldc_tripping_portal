using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            // Owner name is unique
            builder
            .HasIndex(o => o.Name)
            .IsUnique();
        }
    }
}
