using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ECS.Models;

public partial class EcsContext : DbContext
{
    public EcsContext()
    {
    }

    public EcsContext(DbContextOptions<EcsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Otprequest> Otprequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=ECS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Otprequest>(entity =>
        {
            entity.HasKey(e => e.OtpId).HasName("PK__OTPReque__3143C4A326DFC721");

            entity.ToTable("OTPRequest");

            entity.Property(e => e.AttemptsLeft).HasDefaultValue(3);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpirationTime).HasColumnType("datetime");
            entity.Property(e => e.IsUsed).HasDefaultValue(false);
            entity.Property(e => e.OtpCode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Purpose)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Otprequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OTPRequest_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CB32EC2A3");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E444F54E17").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053423078E33").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.BirthDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ExternalProvider)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ProviderKey)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Roles)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("User");
            entity.Property(e => e.Salt)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Other");
            entity.Property(e => e.States)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
