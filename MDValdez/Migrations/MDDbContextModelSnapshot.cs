﻿// <auto-generated />
using System;
using MDValdez.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MDValdez.Migrations
{
    [DbContext(typeof(MDDbContext))]
    partial class MDDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            OrderDate = new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2417)
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            OrderAmount = 100.0,
                            OrderDate = new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2423)
                        },
                        new
                        {
                            OrderId = 3,
                            CustomerId = 3,
                            OrderAmount = 300.0,
                            OrderDate = new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2426)
                        });
                });

            modelBuilder.Entity("MDValdez.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "De beste schoenen ooit",
                            Name = "Mooie schoenen",
                            OrderCode = "beste154",
                            Stock = 0
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Een leuke zomerse T-Shirt",
                            Name = "T-Shirt",
                            OrderCode = "beste11",
                            Stock = 0
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Geweldige broek",
                            Name = "Broek",
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
                            Date = new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2317),
                            TotalPrice = 100.0
                        },
                        new
                        {
                            ShoppingCartId = 2,
                            CustomerId = 1,
                            Date = new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2358),
                            TotalPrice = 200.0
                        },
                        new
                        {
                            ShoppingCartId = 3,
                            CustomerId = 1,
                            Date = new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2360),
                            TotalPrice = 300.0
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
                            CustomerName = "Jan",
                            adress = "Landlaan 1"
                        },
                        new
                        {
                            AccountId = 2,
                            Email = "petertest@hotmail.com",
                            CustomerName = "Peter",
                            adress = "Kade 3"
                        },
                        new
                        {
                            AccountId = 3,
                            Email = "josttest@hotmail.com",
                            CustomerName = "Jost",
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

            modelBuilder.Entity("MDValdez.Models.Product", b =>
                {
                    b.HasOne("MDValdez.Models.ShoppingCart", null)
                        .WithMany("Product")
                        .HasForeignKey("ShoppingCartId");
                });

            modelBuilder.Entity("MDValdez.Models.ShoppingCart", b =>
                {
                    b.HasOne("MDValdez.Models.Customer", null)
                        .WithMany("ShoppingCart")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MDValdez.Models.ShoppingCart", b =>
                {
                    b.Navigation("Product");
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
