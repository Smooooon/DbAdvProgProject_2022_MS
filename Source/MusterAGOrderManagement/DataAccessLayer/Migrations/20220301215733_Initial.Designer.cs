﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MusterAG.DataAccessLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220301215733_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.AddressDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Street = "Teststrasse 1",
                            TownId = 1
                        },
                        new
                        {
                            Id = 2,
                            Street = "Teststrasse 2",
                            TownId = 1
                        },
                        new
                        {
                            Id = 3,
                            Street = "Lolastrasse 1",
                            TownId = 2
                        },
                        new
                        {
                            Id = 4,
                            Street = "Lolastrasse 2",
                            TownId = 2
                        });
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.ArticleDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.ArticleGroupDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("HigherLevelArticleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArticleGroups");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.CountryDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Schweiz"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Deutschland"
                        });
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.CustomerDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Email = "max.muster@muster.com",
                            Name = "Max Muster",
                            Password = "dasPasswort",
                            Website = "muster.com"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            Email = "manuela.sturzi@sturzi.com",
                            Name = "Manuela Sturzi",
                            Password = "dasPasswort2",
                            Website = "sturzi.com"
                        });
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.OrderDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ordered")
                        .HasColumnType("datetime2");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.PositionDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderDaoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderDaoId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.TownDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PLZ")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Towns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "St.Gallen",
                            PLZ = 9000
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Hauptwil",
                            PLZ = 9213
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Konstanz",
                            PLZ = 1111
                        });
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.CustomerDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.AddressDao", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.PositionDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.OrderDao", null)
                        .WithMany("Positions")
                        .HasForeignKey("OrderDaoId");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.TownDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.CountryDao", "Country")
                        .WithMany("TownDao")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.CountryDao", b =>
                {
                    b.Navigation("TownDao");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.OrderDao", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
