using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HospitalManagementApi.Models
{
    public partial class HospitalManagementDBContext : DbContext
    {
        public HospitalManagementDBContext()
        {
        }

        public HospitalManagementDBContext(DbContextOptions<HospitalManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DoctorMapping> DoctorMappings { get; set; }
        public virtual DbSet<DoctorMaster> DoctorMasters { get; set; }
        public virtual DbSet<DoctorTypeMaster> DoctorTypeMasters { get; set; }
        public virtual DbSet<GenderMaster> GenderMasters { get; set; }
        public virtual DbSet<ProductMapping> ProductMappings { get; set; }
        public virtual DbSet<ProductMaster> ProductMasters { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=HospitalManagementDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DoctorMapping>(entity =>
            {
                entity.ToTable("DoctorMapping");

                entity.HasIndex(e => e.DrId, "IX_DoctorMapping_DrId");

                entity.HasIndex(e => e.ProductId, "IX_DoctorMapping_ProductId");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Dr)
                    .WithMany(p => p.DoctorMappings)
                    .HasForeignKey(d => d.DrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorMapping_DoctorMaster");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DoctorMappings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorMapping_ProductMaster");
            });

            modelBuilder.Entity<DoctorMaster>(entity =>
            {
                entity.ToTable("DoctorMaster");

                entity.HasIndex(e => e.DrTypeId, "IX_DoctorMaster_DrTypeId");

                entity.HasIndex(e => e.GenderId, "IX_DoctorMaster_GenderId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DrLicenceNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmargencyMobileNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.PersonalMobileNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DrType)
                    .WithMany(p => p.DoctorMasters)
                    .HasForeignKey(d => d.DrTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorMaster_DoctorTypeMaster");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.DoctorMasters)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorMaster_GenderMaster");
            });

            modelBuilder.Entity<DoctorTypeMaster>(entity =>
            {
                entity.ToTable("DoctorTypeMaster");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DrTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GenderMaster>(entity =>
            {
                entity.ToTable("GenderMaster");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductMapping>(entity =>
            {
                entity.ToTable("ProductMapping");

                entity.HasIndex(e => e.DrTypeId, "IX_ProductMapping_DrTypeId");

                entity.HasIndex(e => e.ProductId, "IX_ProductMapping_ProductId");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.DrType)
                    .WithMany(p => p.ProductMappings)
                    .HasForeignKey(d => d.DrTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMapping_DoctorTypeMaster");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMappings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMapping_ProductMaster");
            });

            modelBuilder.Entity<ProductMaster>(entity =>
            {
                entity.ToTable("ProductMaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ManufactureDate).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Size)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.ToTable("UserMaster");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
