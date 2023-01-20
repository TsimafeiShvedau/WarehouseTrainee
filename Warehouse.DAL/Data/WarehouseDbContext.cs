using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Warehouse.DAL.DataModels;

namespace Warehouse.DAL.Data;

public partial class WarehouseDbContext : DbContext
{
    public WarehouseDbContext()
    {
    }

    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                => optionsBuilder.UseSqlServer("Data Source=TSIMAFEISHVEDAU;Initial Catalog=WarehouseDB; Integrated Security=True; Trust Server Certificate=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {

            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Department).WithMany(p => p.Products)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Product_Department");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.ToTable("Worker");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(15);

            entity.HasMany(d => d.Departments).WithMany(p => p.Workers)
                .UsingEntity<Dictionary<string, object>>(
                    "WorkersDepartment",
                    r => r.HasOne<Department>().WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Workers_D__depar__35BCFE0A"),
                    l => l.HasOne<Worker>().WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Workers_D__worke__34C8D9D1"),
                    j =>
                    {
                        j.HasKey("WorkerId", "DepartmentId").HasName("worker_department_pk");
                        j.ToTable("Workers_Departments");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
