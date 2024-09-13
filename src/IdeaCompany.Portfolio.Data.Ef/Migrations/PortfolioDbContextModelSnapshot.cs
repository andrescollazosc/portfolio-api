﻿// <auto-generated />
using System;
using IdeaCompany.Portfolio.Data.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IdeaCompany.Portfolio.Data.Ef.Migrations
{
    [DbContext(typeof(PortfolioDbContext))]
    partial class PortfolioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IdeaCompany.Portfolio.Core.EmailSettings.Models.EmailSetting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordApplication")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SmtpClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.ToTable("EmailSettings");
                });

            modelBuilder.Entity("IdeaCompany.Portfolio.Core.Portfolios.Models.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Emails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("OwnerFirstName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("OwnerLastName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("PhoneNumbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortfolioTag")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SocialMedias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioTag")
                        .IsUnique();

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("IdeaCompany.Portfolio.Core.Portfolios.Models.WorkExperience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("IconCompany")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PortfolioId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UrlCompany")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("PortfolioId1");

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("IdeaCompany.Portfolio.Core.EmailSettings.Models.EmailSetting", b =>
                {
                    b.HasOne("IdeaCompany.Portfolio.Core.Portfolios.Models.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("IdeaCompany.Portfolio.Core.Portfolios.Models.WorkExperience", b =>
                {
                    b.HasOne("IdeaCompany.Portfolio.Core.Portfolios.Models.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdeaCompany.Portfolio.Core.Portfolios.Models.Portfolio", null)
                        .WithMany("WorkExperiences")
                        .HasForeignKey("PortfolioId1");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("IdeaCompany.Portfolio.Core.Portfolios.Models.Portfolio", b =>
                {
                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
