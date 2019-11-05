using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TrippingPortal.Core;

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

            // Owner name is unique
            builder.Entity<Owner>()
            .HasIndex(o => o.Name)
            .IsUnique();

            // Many to Many relationship of Utility owners
            builder.Entity<UtilityOwner>().HasKey(uo => new { uo.UtilityId, uo.OwnerId });
            builder.Entity<UtilityOwner>()
                .HasOne(uo => uo.Utility)
                .WithMany()
                .HasForeignKey(uo => uo.UtilityId);
            builder.Entity<UtilityOwner>()
                .HasOne(uo => uo.Owner)
                .WithMany()
                .HasForeignKey(uo => uo.OwnerId);

            // EventClassification name is unique
            builder.Entity<EventClassification>()
            .HasIndex(ec => ec.Name)
            .IsUnique();

            // Default value of EventEL CreatedAt
            builder.Entity<EventEL>()
                .Property(e => e.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            // Default value of EventEL UpdatedAt and auto update modify
            builder.Entity<EventEL>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();

            // Many to Many relationship of Trippings and Element Owners
            builder.Entity<TrippingElementOwner>().HasKey(teo => new { teo.TrippingId, teo.OwnerId });
            builder.Entity<TrippingElementOwner>()
                .HasOne(teo => teo.Tripping)
                .WithMany()
                .HasForeignKey(teo => teo.TrippingId);
            builder.Entity<TrippingElementOwner>()
                .HasOne(teo => teo.Owner)
                .WithMany()
                .HasForeignKey(teo => teo.OwnerId);

            // Many to Many relationship of Trippings and Bay Owners
            builder.Entity<TrippingBayOwner>().HasKey(tbo => new { tbo.TrippingId, tbo.OwnerId });
            builder.Entity<TrippingBayOwner>()
                .HasOne(tbo => tbo.Tripping)
                .WithMany()
                .HasForeignKey(tbo => tbo.TrippingId);
            builder.Entity<TrippingBayOwner>()
                .HasOne(tbo => tbo.Owner)
                .WithMany()
                .HasForeignKey(tbo => tbo.OwnerId);

            // Default value of TrippingEL CreatedAt
            builder.Entity<TrippingEL>()
                .Property(tel => tel.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            // Default value of TrippingEL UpdatedAt and auto update modify
            builder.Entity<TrippingEL>()
                .Property(tel => tel.UpdatedAt)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();

            // Default value of TrippingDR CreatedAt
            builder.Entity<TrippingDR>()
                .Property(tel => tel.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            // Default value of TrippingDR UpdatedAt and auto update modify
            builder.Entity<TrippingDR>()
                .Property(tel => tel.UpdatedAt)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
