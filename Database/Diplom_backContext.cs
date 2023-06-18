using System;
using System.Collections.Generic;
using Diplom_back.Models;
using Microsoft.EntityFrameworkCore;

namespace Diplom_back.Database;

public partial class Diplom_backContext : DbContext
{
    public Diplom_backContext(DbContextOptions<Diplom_backContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankRequisite> BankRequisites { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyType> CompanyTypes { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<DealsHasProduct> DealsHasProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Requisite> Requisites { get; set; }

    public virtual DbSet<RequisiteType> RequisiteTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<BankRequisite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(128);
            entity.Property(e => e.Bic)
                .HasMaxLength(45)
                .HasColumnName("BIC");
            entity.Property(e => e.FullName)
                .HasMaxLength(256)
                .HasColumnName("Full_name");
            entity.Property(e => e.Ks)
                .HasMaxLength(45)
                .HasColumnName("KS");
            entity.Property(e => e.Rs)
                .HasMaxLength(45)
                .HasColumnName("RS");
            entity.Property(e => e.ShortName)
                .HasMaxLength(128)
                .HasColumnName("Short_name");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyTypeId).HasColumnName("CompanyTypeID");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.FullName)
                .HasMaxLength(256)
                .HasColumnName("Full_name");
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.ShortName)
                .HasMaxLength(128)
                .HasColumnName("Short_name");
        });

        modelBuilder.Entity<CompanyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("Last_name");
            entity.Property(e => e.PersonalPhone)
                .HasMaxLength(45)
                .HasColumnName("Personal_phone");
            entity.Property(e => e.SecondName)
                .HasMaxLength(45)
                .HasColumnName("Second_name");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(45)
                .HasColumnName("Work_phone");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CloseDate)
                .HasColumnType("datetime")
                .HasColumnName("Close_date");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_date");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
            entity.Property(e => e.Number).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(10);
        });

        modelBuilder.Entity<DealsHasProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Deals_has_Products");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("NAME");
            entity.Property(e => e.Price).HasPrecision(10);
        });

        modelBuilder.Entity<Requisite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FullName)
                .HasMaxLength(256)
                .HasColumnName("Full_name");
            entity.Property(e => e.Inn)
                .HasMaxLength(45)
                .HasColumnName("INN");
            entity.Property(e => e.Kpp)
                .HasMaxLength(45)
                .HasColumnName("KPP");
            entity.Property(e => e.Ogrn)
                .HasMaxLength(45)
                .HasColumnName("OGRN");
            entity.Property(e => e.Okpo)
                .HasMaxLength(45)
                .HasColumnName("OKPO");
            entity.Property(e => e.ShortName)
                .HasMaxLength(128)
                .HasColumnName("Short_name");
        });

        modelBuilder.Entity<RequisiteType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BirthDate).HasColumnName("Birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("Last_name");
            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.PersonalPhone)
                .HasMaxLength(11)
                .HasColumnName("Personal_phone");
            entity.Property(e => e.SecondName)
                .HasMaxLength(45)
                .HasColumnName("Second_name");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(11)
                .HasColumnName("Work_phone");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
