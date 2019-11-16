using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using TrippingPortal.Core.Entities;

namespace TrippingPortal.Data
{
    public class TrippingPortalDbContext : IdentityDbContext
    {
        public TrippingPortalDbContext(DbContextOptions<TrippingPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<UtilityOwner> UtilityOwners { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventClassification> EventClassifications { get; set; }
        public DbSet<EventEL> EventELs { get; set; }
        public DbSet<Tripping> Trippings { get; set; }
        public DbSet<TrippingElementOwner> TrippingElementOwners { get; set; }
        public DbSet<TrippingBayOwner> TrippingBayOwners { get; set; }
        public DbSet<TrippingDR> TrippingDRs { get; set; }
        public DbSet<TrippingEL> TrippingELs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
