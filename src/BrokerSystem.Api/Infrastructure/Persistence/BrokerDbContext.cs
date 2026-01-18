using System;
using System.Collections.Generic;
using BrokerSystem.Api.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Infrastructure.Persistence;

public partial class BrokerDbContext : DbContext
{
    public BrokerDbContext()
    {
    }

    public BrokerDbContext(DbContextOptions<BrokerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<claim> claims { get; set; }

    public virtual DbSet<client> clients { get; set; }

    public virtual DbSet<policy> policies { get; set; }

    public virtual DbSet<policy_type> policy_types { get; set; }

    public virtual DbSet<risk_assessment> risk_assessments { get; set; }

    public virtual DbSet<vw_active_policy> vw_active_policies { get; set; }

    public virtual DbSet<vw_client_summary> vw_client_summaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("claim_status", new[] { "New", "InProgress", "Closed" })
            .HasPostgresEnum("policy_status", new[] { "Active", "Expired", "Cancelled" })
            .HasPostgresEnum("risk_level", new[] { "Low", "Medium", "High" });

        modelBuilder.Entity<claim>(entity =>
        {
            entity.HasKey(e => e.id).HasName("claims_pkey");

            entity.HasOne(d => d.policy).WithMany(p => p.claims)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("claims_policy_id_fkey");
        });

        modelBuilder.Entity<client>(entity =>
        {
            entity.HasKey(e => e.id).HasName("clients_pkey");

            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_active).HasDefaultValue(true);
        });

        modelBuilder.Entity<policy>(entity =>
        {
            entity.HasKey(e => e.id).HasName("policies_pkey");

            entity.HasOne(d => d.client).WithMany(p => p.policies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("policies_client_id_fkey");

            entity.HasOne(d => d.policy_type).WithMany(p => p.policies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("policies_policy_type_id_fkey");
        });

        modelBuilder.Entity<policy_type>(entity =>
        {
            entity.HasKey(e => e.id).HasName("policy_types_pkey");
        });

        modelBuilder.Entity<risk_assessment>(entity =>
        {
            entity.HasKey(e => e.id).HasName("risk_assessments_pkey");

            entity.Property(e => e.assessed_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.client).WithMany(p => p.risk_assessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("risk_assessments_client_id_fkey");
        });

        modelBuilder.Entity<vw_active_policy>(entity =>
        {
            entity.ToView("vw_active_policies");
        });

        modelBuilder.Entity<vw_client_summary>(entity =>
        {
            entity.ToView("vw_client_summary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
