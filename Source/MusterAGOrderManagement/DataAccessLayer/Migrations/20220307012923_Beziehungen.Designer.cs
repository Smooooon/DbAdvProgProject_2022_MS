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
    [Migration("20220307012923_Beziehungen")]
    partial class Beziehungen
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

                    b.HasIndex("TownId");

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

                    b.HasIndex("ArticleGroupId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleGroupId = 9,
                            Name = "Vollkornbrot",
                            Price = 4.20m
                        },
                        new
                        {
                            Id = 2,
                            ArticleGroupId = 9,
                            Name = "Zopf",
                            Price = 5.80m
                        },
                        new
                        {
                            Id = 3,
                            ArticleGroupId = 3,
                            Name = "Appenzeller",
                            Price = 34.00m
                        },
                        new
                        {
                            Id = 4,
                            ArticleGroupId = 3,
                            Name = "Eierlikör",
                            Price = 8.70m
                        },
                        new
                        {
                            Id = 5,
                            ArticleGroupId = 2,
                            Name = "Sinalco",
                            Price = 3.40m
                        });
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

                    b.HasIndex("HigherLevelArticleGroupId")
                        .IsUnique()
                        .HasFilter("[HigherLevelArticleGroupId] IS NOT NULL");

                    b.ToTable("ArticleGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lebensmittel"
                        },
                        new
                        {
                            Id = 2,
                            HigherLevelArticleGroupId = 1,
                            Name = "Getränke"
                        },
                        new
                        {
                            Id = 3,
                            HigherLevelArticleGroupId = 2,
                            Name = "Alkohol"
                        },
                        new
                        {
                            Id = 4,
                            HigherLevelArticleGroupId = 2,
                            Name = "Non-Alkohol"
                        },
                        new
                        {
                            Id = 5,
                            HigherLevelArticleGroupId = 3,
                            Name = "Likör"
                        },
                        new
                        {
                            Id = 6,
                            HigherLevelArticleGroupId = 3,
                            Name = "Kreuterschnaps"
                        },
                        new
                        {
                            Id = 7,
                            HigherLevelArticleGroupId = 2,
                            Name = "Fleisch"
                        },
                        new
                        {
                            Id = 8,
                            HigherLevelArticleGroupId = 2,
                            Name = "Obst"
                        },
                        new
                        {
                            Id = 9,
                            HigherLevelArticleGroupId = 2,
                            Name = "Getreide"
                        },
                        new
                        {
                            Id = 10,
                            HigherLevelArticleGroupId = 9,
                            Name = "Teigwaren"
                        },
                        new
                        {
                            Id = 11,
                            HigherLevelArticleGroupId = 9,
                            Name = "Brot"
                        });
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

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            CustomerId = 1,
                            Ordered = new DateTime(2022, 2, 27, 8, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Ordered = new DateTime(2022, 3, 1, 12, 5, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Ordered = new DateTime(2022, 3, 2, 15, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.PositionDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("OrderId");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            ArticleId = 4,
                            OrderId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            ArticleId = 3,
                            OrderId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 4,
                            ArticleId = 5,
                            OrderId = 2,
                            Quantity = 6
                        },
                        new
                        {
                            Id = 5,
                            ArticleId = 2,
                            OrderId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            ArticleId = 5,
                            OrderId = 3,
                            Quantity = 6
                        });
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

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.AddressDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.TownDao", "Town")
                        .WithMany("Addresses")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Town");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.ArticleDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.ArticleGroupDao", "ArticleGroup")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleGroup");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.ArticleGroupDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.ArticleGroupDao", null)
                        .WithOne("HigherLevelArticleGroup")
                        .HasForeignKey("MusterAG.DataAccessLayer.Dao.ArticleGroupDao", "HigherLevelArticleGroupId");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.CustomerDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.AddressDao", "Address")
                        .WithMany("Customers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.OrderDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.CustomerDao", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.PositionDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.ArticleDao", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusterAG.DataAccessLayer.Dao.OrderDao", "Order")
                        .WithMany("Positions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.TownDao", b =>
                {
                    b.HasOne("MusterAG.DataAccessLayer.Dao.CountryDao", "Country")
                        .WithMany("Towns")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.AddressDao", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.ArticleGroupDao", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("HigherLevelArticleGroup")
                        .IsRequired();
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.CountryDao", b =>
                {
                    b.Navigation("Towns");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.OrderDao", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("MusterAG.DataAccessLayer.Dao.TownDao", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
