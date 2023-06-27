using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dayeva.Models;

public partial class AuctionContext : DbContext
{
    public AuctionContext()
    {
    }

    public AuctionContext(DbContextOptions<AuctionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonalDatum> PersonalData { get; set; }

    public virtual DbSet<ProductAuction> ProductAuctions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=81.177.6.104;user=prof_user1;password=WsrWsrWsr2021$;database=Auction", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.19-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<PersonalDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "PersonalData_FK");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NumberPassport)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Patronomic).HasMaxLength(100);
            entity.Property(e => e.SeriesPassport)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.Surname).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.PersonalData)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("PersonalData_FK");
        });

        modelBuilder.Entity<ProductAuction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ProductAuction");

            entity.HasIndex(e => e.StatusId, "ProductAuction_FK");

            entity.HasIndex(e => e.PersonalDataId, "ProductAuction_FK_1");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PersonalDataId).HasColumnType("int(11)");
            entity.Property(e => e.PriceEnd).HasMaxLength(100);
            entity.Property(e => e.PriceStart).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnType("int(11)");

            entity.HasOne(d => d.PersonalData).WithMany(p => p.ProductAuctions)
                .HasForeignKey(d => d.PersonalDataId)
                .HasConstraintName("ProductAuction_FK_1");

            entity.HasOne(d => d.Status).WithMany(p => p.ProductAuctions)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("ProductAuction_FK");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NameRole).HasMaxLength(100);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("User");

            entity.HasIndex(e => e.RoleId, "User_FK");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnType("int(11)");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
