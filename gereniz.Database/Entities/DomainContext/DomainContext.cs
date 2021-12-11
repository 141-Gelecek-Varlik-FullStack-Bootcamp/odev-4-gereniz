using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using gereniz.Database.Entities;

#nullable disable

namespace gereniz.Database.Entities.DomainContext
{
    public partial class DomainContext : DbContext
    {
        public DomainContext()
        {
        }

        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Baskets> Baskets { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.41;Database=Lesson2;User ID = asusasus;Password = 123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Baskets>(entity =>
            {
                entity.Property(e => e.CreateDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateDatetime).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Baskets_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Baskets_Users");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.Idatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("IDatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Iuser).HasColumnName("IUser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Udatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("UDatetime");

                entity.Property(e => e.Uuser).HasColumnName("UUser");

                entity.HasOne(d => d.IuserNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.Iuser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categories_Users");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.Idatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("IDatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Iuser).HasColumnName("IUser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Udatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("UDatetime");

                entity.Property(e => e.Uuser).HasColumnName("UUser");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.IuserNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Iuser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("IDateTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Iuser).HasColumnName("IUser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UDateTime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Uuser).HasColumnName("UUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
