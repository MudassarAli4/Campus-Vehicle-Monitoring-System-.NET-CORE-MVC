using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web.Models;

public partial class CUsersAhmadMurtazaDocumentsEndMdfContext : DbContext
{
    public CUsersAhmadMurtazaDocumentsEndMdfContext()
    {
    }

    public CUsersAhmadMurtazaDocumentsEndMdfContext(DbContextOptions<CUsersAhmadMurtazaDocumentsEndMdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InOut> InOuts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=sql.bsite.net\\MSSQL2016;Initial Catalog=murtaza2233_mydb;User ID=murtaza2233_mydb;Password=123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InOut>(entity =>
        {
            entity.HasKey(e => e.EntryId);

            entity.ToTable("InOut");

            entity.Property(e => e.EntryDateTime).HasColumnType("datetime");
            entity.Property(e => e.ExitDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.InOuts)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InOut_Vehicle");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F008EE211");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cnic)
                .HasMaxLength(15)
                .HasColumnName("cnic");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Vid).HasName("PK__Vehicle__C5DF235B12EA753E");

            entity.ToTable("Vehicle");

            entity.Property(e => e.Vid).HasColumnName("VId");
            entity.Property(e => e.Vname)
                .HasMaxLength(50)
                .HasColumnName("VName");
            entity.Property(e => e.Vowner)
                .HasMaxLength(50)
                .HasColumnName("VOwner");
            entity.Property(e => e.Vplate)
                .HasMaxLength(15)
                .HasColumnName("VPlate");
            entity.Property(e => e.Vtype)
                .HasMaxLength(50)
                .HasColumnName("VType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
