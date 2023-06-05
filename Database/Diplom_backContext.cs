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

            entity.HasIndex(e => e.RequisitesId, "fk_BankRequisites_Requisites1_idx");

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
            entity.Property(e => e.RequisitesId).HasColumnName("Requisites_ID");
            entity.Property(e => e.Rs)
                .HasMaxLength(45)
                .HasColumnName("RS");
            entity.Property(e => e.ShortName)
                .HasMaxLength(128)
                .HasColumnName("Short_name");

            entity.HasOne(d => d.Requisites).WithMany(p => p.BankRequisites)
                .HasForeignKey(d => d.RequisitesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_BankRequisites_Requisites1");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyTypesId, "fk_Companies_CompanyTypes1_idx");

            entity.HasIndex(e => e.UsersId, "fk_Companies_Users1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyTypesId).HasColumnName("CompanyTypes_ID");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.FullName)
                .HasMaxLength(256)
                .HasColumnName("Full_name");
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.ShortName)
                .HasMaxLength(128)
                .HasColumnName("Short_name");
            entity.Property(e => e.UsersId).HasColumnName("Users_ID");

            entity.HasOne(d => d.CompanyTypes).WithMany(p => p.Companies)
                .HasForeignKey(d => d.CompanyTypesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Companies_CompanyTypes1");

            entity.HasOne(d => d.Users).WithMany(p => p.Companies)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Companies_Users1");
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

            entity.HasIndex(e => e.CompaniesId, "fk_Contacts_Companies1_idx");

            entity.HasIndex(e => e.UsersId, "fk_Contacts_Users1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompaniesId).HasColumnName("Companies_ID");
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
            entity.Property(e => e.UsersId).HasColumnName("Users_ID");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(45)
                .HasColumnName("Work_phone");

            entity.HasOne(d => d.Companies).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CompaniesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contacts_Companies1");

            entity.HasOne(d => d.Users).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contacts_Users1");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompaniesId, "fk_Deals_Companies1_idx");

            entity.HasIndex(e => e.ContactsId, "fk_Deals_Contacts1_idx");

            entity.HasIndex(e => e.UsersId, "fk_Deals_Users1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CloseDate)
                .HasColumnType("datetime")
                .HasColumnName("Close_date");
            entity.Property(e => e.CompaniesId).HasColumnName("Companies_ID");
            entity.Property(e => e.ContactsId).HasColumnName("Contacts_ID");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_date");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("NAME");
            entity.Property(e => e.Number).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.UsersId).HasColumnName("Users_ID");

            entity.HasOne(d => d.Companies).WithMany(p => p.Deals)
                .HasForeignKey(d => d.CompaniesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Deals_Companies1");

            entity.HasOne(d => d.Contacts).WithMany(p => p.Deals)
                .HasForeignKey(d => d.ContactsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Deals_Contacts1");

            entity.HasOne(d => d.Users).WithMany(p => p.Deals)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Deals_Users1");

            entity.HasMany(d => d.Products).WithMany(p => p.Deals)
                .UsingEntity<Dictionary<string, object>>(
                    "DealsHasProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Deals_has_Products_Products1"),
                    l => l.HasOne<Deal>().WithMany()
                        .HasForeignKey("DealsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Deals_has_Products_Deals1"),
                    j =>
                    {
                        j.HasKey("DealsId", "ProductsId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("Deals_has_Products");
                        j.HasIndex(new[] { "DealsId" }, "fk_Deals_has_Products_Deals1_idx");
                        j.HasIndex(new[] { "ProductsId" }, "fk_Deals_has_Products_Products1_idx");
                        j.IndexerProperty<int>("DealsId").HasColumnName("Deals_ID");
                        j.IndexerProperty<int>("ProductsId").HasColumnName("Products_ID");
                    });
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

            entity.HasIndex(e => e.CompaniesId, "fk_Requisites_Companies1_idx");

            entity.HasIndex(e => e.RequisiteTypesId, "fk_Requisites_RequisiteTypes1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompaniesId).HasColumnName("Companies_ID");
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
            entity.Property(e => e.RequisiteTypesId).HasColumnName("RequisiteTypes_ID");
            entity.Property(e => e.ShortName)
                .HasMaxLength(128)
                .HasColumnName("Short_name");

            entity.HasOne(d => d.Companies).WithMany(p => p.Requisites)
                .HasForeignKey(d => d.CompaniesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Requisites_Companies1");

            entity.HasOne(d => d.RequisiteTypes).WithMany(p => p.Requisites)
                .HasForeignKey(d => d.RequisiteTypesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Requisites_RequisiteTypes1");
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

            entity.HasIndex(e => e.UserTypesId, "fk_Users_UserTypes_idx");

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
            entity.Property(e => e.UserTypesId).HasColumnName("UserTypes_ID");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(11)
                .HasColumnName("Work_phone");

            entity.HasOne(d => d.UserTypes).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Users_UserTypes");
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
