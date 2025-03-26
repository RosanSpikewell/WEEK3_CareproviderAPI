using System;
using System.Collections.Generic;
using CareProviderAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CareProviderAPI.Data.Context;

public partial class CareproviderContext : DbContext
{
    public CareproviderContext()
    {
    }

    public CareproviderContext(DbContextOptions<CareproviderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<CareProvider> CareProviders { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SW0103002;Database=careprovider;User Id=TEST;Password=Test@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Achievem__3214EC271288508C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CareProviderId).HasColumnName("CareProviderID");

            entity.HasOne(d => d.CareProvider).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.CareProviderId)
                .HasConstraintName("FK_Achievements_CareProvider");
        });

        modelBuilder.Entity<CareProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CareProv__3214EC27E304A430");

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
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC2765FD37C3");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC27B12FD7E8");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CareProviderId).HasColumnName("CareProviderID");
            entity.Property(e => e.HospitalName).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);

            entity.HasOne(d => d.CareProvider).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.CareProviderId)
                .HasConstraintName("FK_Experiences_CareProvider");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
