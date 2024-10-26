using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Camp6_Final_Angular.Models;

public partial class LoanManagementContext : DbContext
{
    public LoanManagementContext()
    {
    }

    public LoanManagementContext(DbContextOptions<LoanManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BackgroundVerification> BackgroundVerifications { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<HelpSection> HelpSections { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog =LoanManagement; Integrated Security = True; \nTrusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BackgroundVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__Backgrou__306D4927C17DDBA7");

            entity.ToTable("BackgroundVerification");

            entity.Property(e => e.VerificationId).HasColumnName("VerificationID");
            entity.Property(e => e.AssignedOfficerId).HasColumnName("AssignedOfficerID");
            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.AssignedOfficer).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.AssignedOfficerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Backgroun__Assig__3D5E1FD2");

            entity.HasOne(d => d.Loan).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.LoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Backgroun__LoanI__3C69FB99");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B84CEE1AE8");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E3864C79CA8").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534ECF40D5C").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF64685ADD6");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FeedbackDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Custom__4316F928");
        });

        modelBuilder.Entity<HelpSection>(entity =>
        {
            entity.HasKey(e => e.HelpId).HasName("PK__HelpSect__90E3232EE06C83A6");

            entity.ToTable("HelpSection");

            entity.Property(e => e.HelpId).HasColumnName("HelpID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__4F5AD437DFC4DE07");

            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.ApplicationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AssignedOfficerId).HasColumnName("AssignedOfficerID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.LoanAmount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.LoanType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.AssignedOfficer).WithMany(p => p.Loans)
                .HasForeignKey(d => d.AssignedOfficerId)
                .HasConstraintName("FK__Loans__AssignedO__37A5467C");

            entity.HasOne(d => d.Customer).WithMany(p => p.Loans)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loans__CustomerI__36B12243");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PK__Login__4DDA28180399DB95");

            entity.ToTable("Login");

            entity.HasIndex(e => e.Username, "UQ__Login__536C85E41289A972").IsUnique();

            entity.HasIndex(e => e.StaffId, "UQ__Login__96D4AB1678CC91D1").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Staff).WithOne(p => p.Login)
                .HasForeignKey<Login>(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Login_Staff");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A83B93BE4");

            entity.Property(e => e.RoleName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7FA0AE5D9");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Staff__85FB4E38E8D0013F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Staff__A9D10534B65B3143").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Role).WithMany(p => p.Staff)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
