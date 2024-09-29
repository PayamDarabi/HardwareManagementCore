using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HardwareManagement_.core_.Models.Entity
{
    public partial class HardwaremanagementContext : DbContext
    {
        public HardwaremanagementContext()
        {
        }

        public HardwaremanagementContext(DbContextOptions<HardwaremanagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblHardware> TblHardwares { get; set; } = null!;
        public virtual DbSet<TblHistory> TblHistories { get; set; } = null!;
        public virtual DbSet<TblLocation> TblLocations { get; set; } = null!;
        public virtual DbSet<TblModel> TblModels { get; set; } = null!;
        public virtual DbSet<TblPerson> TblPeople { get; set; } = null!;
        public virtual DbSet<TblStatus> TblStatuses { get; set; } = null!;
        public virtual DbSet<TblStatusHw> TblStatusHws { get; set; } = null!;
        public virtual DbSet<TblStore> TblStores { get; set; } = null!;
        public virtual DbSet<TblTitle> TblTitles { get; set; } = null!;
        public virtual DbSet<TblUnit> TblUnits { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database='Hardware management';Trusted_Connection=True;MultipleActiveResultSets=true", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Persian_100_CI_AI");

            modelBuilder.Entity<TblHardware>(entity =>
            {
                entity.HasKey(e => e.AssetNo);

                entity.ToTable("tblHardwares");

                entity.Property(e => e.AssetNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.AssignDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecieveDate).HasColumnType("date");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.StatusHw).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .UseCollation("Arabic_CI_AS");
            });

            modelBuilder.Entity<TblHistory>(entity =>
            {
                entity.ToTable("tblHistory");

                entity.Property(e => e.AssetNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AssignDate).HasColumnType("date");

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.OutOfDate).HasColumnType("date");

                entity.Property(e => e.RecieveDate).HasColumnType("date");

                entity.Property(e => e.RepairDate).HasColumnType("date");

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusHw).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UserSender)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("tblLocation");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.Property(e => e.Location).HasMaxLength(50);
            });

            modelBuilder.Entity<TblModel>(entity =>
            {
                entity.ToTable("tblModel");

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("tblPerson");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Phone)
                    .IsUnicode(false)
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.Status).HasMaxLength(200);

                entity.Property(e => e.Unit)
                    .HasMaxLength(32)
                    .UseCollation("Arabic_CI_AS");
            });

            modelBuilder.Entity<TblStatus>(entity =>
            {
                entity.ToTable("tblStatus");

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<TblStatusHw>(entity =>
            {
                entity.ToTable("tblStatusHw");

                entity.Property(e => e.StatusHw).HasMaxLength(100);
            });

            modelBuilder.Entity<TblStore>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.ToTable("tblStore");

                entity.Property(e => e.StLocation)
                    .HasMaxLength(50)
                    .UseCollation("Arabic_CI_AS");
            });

            modelBuilder.Entity<TblTitle>(entity =>
            {
                entity.ToTable("tblTitle");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<TblUnit>(entity =>
            {
                entity.ToTable("tblUnit");

                entity.Property(e => e.Unit).HasMaxLength(100);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .UseCollation("Arabic_CI_AS");

                entity.Property(e => e.UserName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .UseCollation("Arabic_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
