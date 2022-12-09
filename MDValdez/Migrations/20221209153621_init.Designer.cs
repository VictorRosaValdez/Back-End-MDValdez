﻿// <auto-generated />
using System;
using MDValdez.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MDValdez.Migrations
{
    [DbContext(typeof(MDDbContext))]
    [Migration("20221209153621_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MDValdez.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Account");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Account");
                });

            modelBuilder.Entity("MDValdez.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("OrderAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            OrderAmount = 250.5,
                            OrderDate = new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4692)
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            OrderAmount = 100.0,
                            OrderDate = new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4696)
                        },
                        new
                        {
                            OrderId = 3,
                            CustomerId = 3,
                            OrderAmount = 300.0,
                            OrderDate = new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4698)
                        });
                });

            modelBuilder.Entity("MDValdez.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = "coat",
                            Description = "De beste jas ooit",
                            Name = "Mooie Jas",
                            OrderCode = "beste154",
                            Stock = 0
                        },
                        new
                        {
                            ProductId = 2,
                            Category = "jewelry",
                            Description = "Gouden sieraden",
                            Name = "Mooie sieraden",
                            OrderCode = "beste11",
                            Stock = 0
                        },
                        new
                        {
                            ProductId = 3,
                            Category = "shoes",
                            Description = "De beste schoenen ooit gemaakt",
                            Name = "Beste schoenen ooit",
                            OrderCode = "beste1122",
                            Stock = 0
                        });
                });

            modelBuilder.Entity("MDValdez.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ShoppingCart");

                    b.HasData(
                        new
                        {
                            ShoppingCartId = 1,
                            CustomerId = 2,
                            Date = new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4615),
                            TotalPrice = 100.0
                        },
                        new
                        {
                            ShoppingCartId = 2,
                            CustomerId = 1,
                            Date = new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4665),
                            TotalPrice = 200.0
                        },
                        new
                        {
                            ShoppingCartId = 3,
                            CustomerId = 1,
                            Date = new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4668),
                            TotalPrice = 300.0
                        });
                });

            modelBuilder.Entity("MDValdez.Models.ShoppingCartProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ShoppingCartId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartProduct");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ShoppingCartId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            ShoppingCartId = 2
                        },
                        new
                        {
                            ProductId = 1,
                            ShoppingCartId = 3
                        });
                });

            modelBuilder.Entity("MDValdez.Models.Customer", b =>
                {
                    b.HasBaseType("MDValdez.Models.Account");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Customer");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            Email = "jantest@hotmail.com",
                            Password = "admin123",
                            CustomerName = "jan",
                            adress = "Landlaan 1"
                        },
                        new
                        {
                            AccountId = 2,
                            Email = "petertest@hotmail.com",
                            Password = "welcome",
                            CustomerName = "peter",
                            adress = "Kade 3"
                        },
                        new
                        {
                            AccountId = 3,
                            Email = "josttest@hotmail.com",
                            Password = "welcome2",
                            CustomerName = "jost",
                            adress = "Sonseweg 15"
                        });
                });

            modelBuilder.Entity("MDValdez.Models.Order", b =>
                {
                    b.HasOne("MDValdez.Models.Customer", null)
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MDValdez.Models.ShoppingCart", b =>
                {
                    b.HasOne("MDValdez.Models.Customer", null)
                        .WithMany("ShoppingCart")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MDValdez.Models.ShoppingCartProduct", b =>
                {
                    b.HasOne("MDValdez.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MDValdez.Models.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("MDValdez.Models.Customer", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("ShoppingCart");
                });
#pragma warning restore 612, 618
        }
    }
}