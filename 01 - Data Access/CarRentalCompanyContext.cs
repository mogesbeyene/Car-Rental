using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRental;

public partial class CarRentalCompanyContext : DbContext
{
    public CarRentalCompanyContext()
    {
    }

    public CarRentalCompanyContext(DbContextOptions<CarRentalCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleType> VehicleTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CarRentalCompany;TrustServerCertificate=True;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK_branches");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.AccurateLocation).HasColumnType("decimal(12, 9)");
            entity.Property(e => e.AddressName).HasMaxLength(30);
            entity.Property(e => e.BranchName).HasMaxLength(30);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActualReturnDate).HasColumnType("datetime");
            entity.Property(e => e.RentalId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RentalID");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_rentals_users");

            entity.HasOne(d => d.Vehicle).WithMany()
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_rentals_vehicles");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.HasIndex(e => e.Id, "UQ__Users__3214EC262493A316").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E447501C69").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534EC617C2E").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.FullName).HasMaxLength(30);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.UserImageName).HasMaxLength(30);
            entity.Property(e => e.UserRole)
                .HasMaxLength(20)
                .HasDefaultValueSql("('User')");
            entity.Property(e => e.Username).HasMaxLength(30);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK_fields");

            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.RentAvailable).HasDefaultValueSql("((1))");
            entity.Property(e => e.RentWorking).HasDefaultValueSql("((1))");
            entity.Property(e => e.VehicleImageName).HasMaxLength(30);
            entity.Property(e => e.VehicleTypeId).HasColumnName("VehicleTypeID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_fields_branches");

            entity.HasOne(d => d.VehicleType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_fields_types");
        });

        modelBuilder.Entity<VehicleType>(entity =>
        {
            entity.HasKey(e => e.VehicleTypeId).HasName("PK_types");

            entity.Property(e => e.VehicleTypeId).HasColumnName("VehicleTypeID");
            entity.Property(e => e.Chalk).HasMaxLength(30);
            entity.Property(e => e.DailyCost).HasColumnType("money");
            entity.Property(e => e.DayLateCost).HasColumnType("money");
            entity.Property(e => e.ManufactureYear).HasColumnType("datetime");
            entity.Property(e => e.Manufacturer).HasMaxLength(30);
            entity.Property(e => e.Model).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
