using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CareProviderAPI.Models;

public partial class CareProviderContext : DbContext
{
    public CareProviderContext()
    {
    }

    public CareProviderContext(DbContextOptions<CareProviderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<CareProvider> CareProviders { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Achievem__3214EC2751B6F33C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CareProviderId).HasColumnName("CareProviderID");

            entity.HasOne(d => d.CareProvider).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.CareProviderId)
                .HasConstraintName("FK_Achievements_CareProvider");
        });

        modelBuilder.Entity<CareProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CareProv__3214EC2709FE339E");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.ContactInfo).HasMaxLength(255);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Department).WithMany(p => p.CareProviders)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_CareProviders_Department");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC27FD40529E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC27DB595CC6");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CareProviderId).HasColumnName("CareProviderID");
            entity.Property(e => e.HospitalName).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);

            entity.HasOne(d => d.CareProvider).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.CareProviderId)
                .HasConstraintName("FK_Experiences_CareProvider");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FA6E4CBDC");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E61648CA5639F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
