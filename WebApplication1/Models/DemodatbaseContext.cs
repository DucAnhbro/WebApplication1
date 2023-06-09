﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class DemodatbaseContext : DbContext
    {
        public DemodatbaseContext()
        {
        }

        public DemodatbaseContext(DbContextOptions<DemodatbaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DetailMotel> DetailMotels { get; set; } = null!;
        public virtual DbSet<Motel> Motels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.0.65.189;Database=Demodatbase; Trust Server Certificate=true;User Id=sa;Password=NTQ@123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DepositPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.RentPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_Customer");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_DetailMotel");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<DetailMotel>(entity =>
            {
                entity.ToTable("DetailMotel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AreaOfRoom).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RoomNumber).HasMaxLength(50);

                entity.HasOne(d => d.Motel)
                    .WithMany(p => p.DetailMotels)
                    .HasForeignKey(d => d.MotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailMotel_Motel");
            });

            modelBuilder.Entity<Motel>(entity =>
            {
                entity.ToTable("Motel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.MotelName).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Motels)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Motel_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
