﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using e_Shop_Demo.Entities;

namespace e_Shop_Demo.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("e_Shop_Demo.Entities.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            ID = new Guid("398023d9-920b-4c27-8f34-00f2bf345100"),
                            Account = "jackson@example.com",
                            Activate = false,
                            BirthDate = new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "_ohjrsvt7bACcAHjb-29hGG7EbXZ1QErLxXHXZMQrPQ",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.Employee", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Activate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = new Guid("e0348ec1-1881-457e-a73f-06910fd306e2"),
                            Account = "manager123@example.com",
                            Activate = false,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C_d2jNWFZ_WvEoOoXMpvXdydnpRQ",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.ImportRecord", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("ImportPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SupplierID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("ImportRecord");

                    b.HasData(
                        new
                        {
                            ID = new Guid("e402d783-521e-4bf2-a472-a1d9dd1ee16a"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 20.0,
                            ProductID = new Guid("242fcdb9-4269-4be7-a8d5-635993d32f59"),
                            Quantity = 100,
                            SupplierID = new Guid("cd0560d4-2881-4f49-a08a-1e12c9cddd38")
                        },
                        new
                        {
                            ID = new Guid("1774a47f-c34b-4158-a54c-a795a0b6590c"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 5000.0,
                            ProductID = new Guid("b0400f04-c7a4-4f0e-85ed-b2c8e20e77e2"),
                            Quantity = 20,
                            SupplierID = new Guid("b11c3daf-d781-4c0c-97d8-280e6f5c11c5")
                        },
                        new
                        {
                            ID = new Guid("f6a384d0-75ec-4f85-91ab-6ebcefbdad2e"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 600.0,
                            ProductID = new Guid("69e2668e-a5fd-4f90-9021-47dda501c216"),
                            Quantity = 30,
                            SupplierID = new Guid("29282b01-7c53-44e2-a667-2e9a5588e659")
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = new Guid("242fcdb9-4269-4be7-a8d5-635993d32f59"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Potato Chips",
                            Price = 30.0,
                            Quantity = 100,
                            Type = 0,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("b0400f04-c7a4-4f0e-85ed-b2c8e20e77e2"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Camera",
                            Price = 9999.0,
                            Quantity = 20,
                            Type = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("69e2668e-a5fd-4f90-9021-47dda501c216"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hair Dryer",
                            Price = 999.0,
                            Quantity = 30,
                            Type = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.PurchaseDetailRecord", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CurrentPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PurchaseRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PurchaseDetailRecord");

                    b.HasData(
                        new
                        {
                            ID = new Guid("2ae95acc-4397-4994-8118-3cd184ab968f"),
                            CurrentPrice = 30.0,
                            ProductID = new Guid("242fcdb9-4269-4be7-a8d5-635993d32f59"),
                            PurchaseRecordId = new Guid("7fe814a6-449e-4161-a5ab-073736ae584b"),
                            Quantity = 5
                        },
                        new
                        {
                            ID = new Guid("d2288737-858e-4e43-8361-f3eac5787a5e"),
                            CurrentPrice = 9999.0,
                            ProductID = new Guid("b0400f04-c7a4-4f0e-85ed-b2c8e20e77e2"),
                            PurchaseRecordId = new Guid("7fe814a6-449e-4161-a5ab-073736ae584b"),
                            Quantity = 1
                        },
                        new
                        {
                            ID = new Guid("0958c47c-32a1-468e-a778-556fff94fed1"),
                            CurrentPrice = 999.0,
                            ProductID = new Guid("69e2668e-a5fd-4f90-9021-47dda501c216"),
                            PurchaseRecordId = new Guid("7fe814a6-449e-4161-a5ab-073736ae584b"),
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.PurchaseRecord", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("PurchaseRecord");

                    b.HasData(
                        new
                        {
                            ID = new Guid("7fe814a6-449e-4161-a5ab-073736ae584b"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerID = new Guid("398023d9-920b-4c27-8f34-00f2bf345100"),
                            PurchaseDate = new DateTime(2020, 12, 16, 15, 12, 30, 0, DateTimeKind.Unspecified),
                            Total = 0.0
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.Supplier", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Supplier");

                    b.HasData(
                        new
                        {
                            ID = new Guid("cd0560d4-2881-4f49-a08a-1e12c9cddd38"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Name = "Food Manufacturer A",
                            Phone = "0956123845",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("b11c3daf-d781-4c0c-97d8-280e6f5c11c5"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Name = "3C Manufacturer A",
                            Phone = "0954778943",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("29282b01-7c53-44e2-a667-2e9a5588e659"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Name = "HairDryer Manufacturer A",
                            Phone = "0989543147",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
