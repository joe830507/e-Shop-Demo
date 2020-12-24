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
                            ID = new Guid("297a7514-a992-4855-b9a4-02f6f6a0fdc3"),
                            Account = "jackson@example.com",
                            Activate = false,
                            BirthDate = new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
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
                            ID = new Guid("0df7712c-1ea8-482c-aff6-db0281f09531"),
                            Account = "manager123@example.com",
                            Activate = false,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
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
                            ID = new Guid("08dd2b51-5e4b-4df7-91f8-74b1051afb37"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 20.0,
                            ProductID = new Guid("e3b0bec4-cddd-4e6d-9d0b-a18d35c82119"),
                            Quantity = 100,
                            SupplierID = new Guid("0e9384c0-9425-47ed-911b-a2d4e18a25e7")
                        },
                        new
                        {
                            ID = new Guid("b94f9361-cc15-4c2b-aa83-45fb8827d1b9"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 5000.0,
                            ProductID = new Guid("185cb220-98ff-4dca-ae69-cfe671042fa9"),
                            Quantity = 20,
                            SupplierID = new Guid("820aadc2-cded-46a0-9652-9dd8a962646a")
                        },
                        new
                        {
                            ID = new Guid("02d99c44-3b8d-4209-a1e6-e7f69b4d0595"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 600.0,
                            ProductID = new Guid("ac96aedc-8b06-4e17-b618-3ee4a30aaa1b"),
                            Quantity = 30,
                            SupplierID = new Guid("0bb68560-187c-4f81-86ff-2ce4b2747e6b")
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

                    b.Property<Guid>("Type")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = new Guid("e3b0bec4-cddd-4e6d-9d0b-a18d35c82119"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Potato Chips",
                            Price = 30.0,
                            Quantity = 100,
                            Type = new Guid("84b06b46-0ae8-444f-92c1-586601700f91"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("185cb220-98ff-4dca-ae69-cfe671042fa9"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Camera",
                            Price = 9999.0,
                            Quantity = 20,
                            Type = new Guid("0eb5ab18-84b4-4ec8-a3e4-cf81a91aa1f5"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("ac96aedc-8b06-4e17-b618-3ee4a30aaa1b"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hair Dryer",
                            Price = 999.0,
                            Quantity = 30,
                            Type = new Guid("7defb3dc-8c16-4c49-bd69-012d5d03b431"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.ProductType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            ID = new Guid("84b06b46-0ae8-444f-92c1-586601700f91"),
                            Name = "Food",
                            Order = 1
                        },
                        new
                        {
                            ID = new Guid("0eb5ab18-84b4-4ec8-a3e4-cf81a91aa1f5"),
                            Name = "Electronic",
                            Order = 2
                        },
                        new
                        {
                            ID = new Guid("7defb3dc-8c16-4c49-bd69-012d5d03b431"),
                            Name = "Home_Appliances",
                            Order = 3
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
                            ID = new Guid("a5944ff9-19ff-449a-b120-613e8a9b7480"),
                            CurrentPrice = 30.0,
                            ProductID = new Guid("e3b0bec4-cddd-4e6d-9d0b-a18d35c82119"),
                            PurchaseRecordId = new Guid("7230b595-a788-4ddc-8bc1-76a0d918a9af"),
                            Quantity = 5
                        },
                        new
                        {
                            ID = new Guid("6ccd2115-00bc-4525-a7c5-c522630ae01b"),
                            CurrentPrice = 9999.0,
                            ProductID = new Guid("185cb220-98ff-4dca-ae69-cfe671042fa9"),
                            PurchaseRecordId = new Guid("7230b595-a788-4ddc-8bc1-76a0d918a9af"),
                            Quantity = 1
                        },
                        new
                        {
                            ID = new Guid("e792b2c1-0dfe-45b1-848d-4e2490b38d08"),
                            CurrentPrice = 999.0,
                            ProductID = new Guid("ac96aedc-8b06-4e17-b618-3ee4a30aaa1b"),
                            PurchaseRecordId = new Guid("7230b595-a788-4ddc-8bc1-76a0d918a9af"),
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
                            ID = new Guid("7230b595-a788-4ddc-8bc1-76a0d918a9af"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerID = new Guid("297a7514-a992-4855-b9a4-02f6f6a0fdc3"),
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
                            ID = new Guid("0e9384c0-9425-47ed-911b-a2d4e18a25e7"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Name = "Food Manufacturer A",
                            Phone = "0956123845",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("820aadc2-cded-46a0-9652-9dd8a962646a"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Name = "3C Manufacturer A",
                            Phone = "0954778943",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("0bb68560-187c-4f81-86ff-2ce4b2747e6b"),
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
