﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using e_Shop_Demo.Entities;

namespace e_Shop_Demo.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20201230104828_InitialCreation")]
    partial class InitialCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            ID = new Guid("16fbe29c-4d9c-4f6a-98e8-7e22ca822efe"),
                            Account = "jackson@example.com",
                            Activate = true,
                            BirthDate = new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("e1bd1f47-b8bf-4640-9024-890afe394112"),
                            Account = "jdsaon@example.com",
                            Activate = true,
                            BirthDate = new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("2e4dedf2-cde2-46af-a1b7-726ab4d86c31"),
                            Account = "jdsao123n@example.com",
                            Activate = true,
                            BirthDate = new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("30d31269-90da-4971-bcdb-9f0dafb92dc2"),
                            Account = "jdsao123n@example.com",
                            Activate = true,
                            BirthDate = new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("dca13509-c8e2-44fb-85be-7f923f596470"),
                            Account = "s4d5623n@example.com",
                            Activate = true,
                            BirthDate = new DateTime(1965, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("6d47b22f-8f13-4f2c-8f87-91064ac98cb3"),
                            Account = "fsado123n@example.com",
                            Activate = true,
                            BirthDate = new DateTime(1952, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("21364f8f-2bcb-4e77-b3ff-46af566bc8c1"),
                            Account = "gds45dn@example.com",
                            Activate = true,
                            BirthDate = new DateTime(1966, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("3b7fedf4-26c2-49aa-a2dd-a65308fad9cb"),
                            Account = "dsad4923n@example.com",
                            Activate = true,
                            BirthDate = new DateTime(2000, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("7250e69c-595c-498e-a922-826a4d3d05d2"),
                            Account = "s46asdn@example.com",
                            Activate = true,
                            BirthDate = new DateTime(1989, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
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

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = new Guid("a5acd1e3-2fa1-48b8-b480-0399b590d8d8"),
                            Account = "admin123@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 0,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("d2a0468a-fe8e-4903-b4e6-4268695cc2b8"),
                            Account = "manager123@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("45445a72-c94e-4c78-82cd-70fc602b0200"),
                            Account = "general123@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("cd8d2c18-fabd-4c3c-8cc4-7d9890320401"),
                            Account = "general456@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("59895b6b-1eff-4a32-9da4-fd04817d6970"),
                            Account = "gene45656@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 0,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("c79b4ce0-5cfc-4060-9d80-ace62017bd36"),
                            Account = "gendsa456@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("dc02ca5c-b36f-4cf7-a12e-6d317b40b8e9"),
                            Account = "gsad5456@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 0,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("de1186bb-f1c7-4f30-9ea1-ce48a6fff690"),
                            Account = "gs49456@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("53f5fb33-e20e-441e-8620-7ec41c0107ac"),
                            Account = "gsaasd55456@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("35eaa279-50ea-47d8-b885-2fd002210c80"),
                            Account = "saad5456@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 0,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("3f92e052-266c-437e-8825-ae73b0209e59"),
                            Account = "gsas8d46@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("fb8a7818-4e67-4ee7-840c-530c136137dd"),
                            Account = "gsasdad46@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("26238d9e-4648-43f4-943d-b9c65e70fa0e"),
                            Account = "a22s8d46@example.com",
                            Activate = true,
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Password = "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=",
                            Role = 1,
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

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("SupplierID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ImportRecord");

                    b.HasData(
                        new
                        {
                            ID = new Guid("a9242e42-b2ec-4af5-8171-9ff8d6881091"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 20.0,
                            ProductID = new Guid("5a17c4dc-90ea-4317-8cd5-1c07909d14aa"),
                            Quantity = 100,
                            Status = 1,
                            SupplierID = new Guid("043e9678-524b-44fb-8f40-4e52633f0397"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("9f45b6f4-0d49-44a2-9d81-56358ba57d12"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 5000.0,
                            ProductID = new Guid("7b2a7372-94c6-4f73-b004-93632c134a07"),
                            Quantity = 20,
                            Status = 1,
                            SupplierID = new Guid("3cbb5266-ccb1-47ec-8ae6-f32f6466998b"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("9e204a6c-f2ff-4ede-a716-cdb47963f7db"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            ImportPrice = 600.0,
                            ProductID = new Guid("48536da9-0218-41d1-92a4-1389070051d4"),
                            Quantity = 30,
                            Status = 1,
                            SupplierID = new Guid("43fc0381-d505-4fd5-81e6-2faff33e0e48"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ProductTypeID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = new Guid("5a17c4dc-90ea-4317-8cd5-1c07909d14aa"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Description = "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽",
                            Name = "洋芋片",
                            PictureLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/640px-Potato-Chips.jpg",
                            Price = 30.0,
                            ProductTypeID = new Guid("5903e594-a661-495f-a6ac-3855407b57a4"),
                            Quantity = 100,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("7b2a7372-94c6-4f73-b004-93632c134a07"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Description = "從夜生活到風景照，都能拍得出色； W810 具備可讓您輕鬆拍出清晰精彩相片與 HD 影片的多項功能。6x 光學變焦可讓您拍出細節豐富的特寫相片，派對模式則可讓您輕鬆捕捉精彩夜生活。",
                            Name = "相機",
                            PictureLink = "https://s.yimg.com/zp/images/F84200C57BFF5B8FB763B09688523E28F99D17E3",
                            Price = 9999.0,
                            ProductTypeID = new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"),
                            Quantity = 20,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("48536da9-0218-41d1-92a4-1389070051d4"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Description = "高滲透奈米水離子水分產量提升1800%;礦物負離子出口角度改變效果更集中",
                            Name = "吹風機",
                            PictureLink = "https://johnlewis.scene7.com/is/image/JohnLewis/237876949",
                            Price = 999.0,
                            ProductTypeID = new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"),
                            Quantity = 30,
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
                            ID = new Guid("5903e594-a661-495f-a6ac-3855407b57a4"),
                            Name = "食品",
                            Order = 1
                        },
                        new
                        {
                            ID = new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"),
                            Name = "消費性電子產品",
                            Order = 2
                        },
                        new
                        {
                            ID = new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"),
                            Name = "家電",
                            Order = 3
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.PurchaseDetailRecord", b =>
                {
                    b.Property<Guid>("PurchaseRecordID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CurrentPrice")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PurchaseRecordID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("PurchaseDetailRecord");

                    b.HasData(
                        new
                        {
                            PurchaseRecordID = new Guid("93ab91cb-9550-4772-90d9-19c7de95c89c"),
                            ProductID = new Guid("5a17c4dc-90ea-4317-8cd5-1c07909d14aa"),
                            CurrentPrice = 30.0,
                            Quantity = 5
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

                    b.HasIndex("CustomerID");

                    b.ToTable("PurchaseRecord");

                    b.HasData(
                        new
                        {
                            ID = new Guid("93ab91cb-9550-4772-90d9-19c7de95c89c"),
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerID = new Guid("16fbe29c-4d9c-4f6a-98e8-7e22ca822efe"),
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

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ProductTypeID");

                    b.ToTable("Supplier");

                    b.HasData(
                        new
                        {
                            ID = new Guid("043e9678-524b-44fb-8f40-4e52633f0397"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "abcmanu@gmail.com",
                            Name = "食品製造商A",
                            Phone = "0956123845",
                            ProductTypeID = new Guid("5903e594-a661-495f-a6ac-3855407b57a4"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("3cbb5266-ccb1-47ec-8ae6-f32f6466998b"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "abcemanu@gmail.com",
                            Name = "3C製造商A",
                            Phone = "0954778943",
                            ProductTypeID = new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("43fc0381-d505-4fd5-81e6-2faff33e0e48"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "dbcmanu@gmail.com",
                            Name = "家電製造商A",
                            Phone = "0989543147",
                            ProductTypeID = new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("4ee255bd-fc22-4fa1-b948-96fd749898f3"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "sabcmanu@gmail.com",
                            Name = "食品製造商C",
                            Phone = "0956185845",
                            ProductTypeID = new Guid("5903e594-a661-495f-a6ac-3855407b57a4"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("b0f654fc-9c37-49c9-9055-50a5e4573726"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "ssaabcemanu@gmail.com",
                            Name = "3C製造商DDD",
                            Phone = "0974778943",
                            ProductTypeID = new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("0174143b-d787-4ca6-8403-c47ab63ca685"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "aasdbcmanu@gmail.com",
                            Name = "家電製造商SDDDA",
                            Phone = "0989546547",
                            ProductTypeID = new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("c88e8f12-0cae-4ce9-9b10-9a6a8eec6d24"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "sadabcmanu@gmail.com",
                            Name = "食品製造商CCC",
                            Phone = "0912123845",
                            ProductTypeID = new Guid("5903e594-a661-495f-a6ac-3855407b57a4"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("bb8d2769-91c8-491f-9cad-bd51a7cef63e"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "as432bcemanu@gmail.com",
                            Name = "3C製造商ASDW",
                            Phone = "0958578943",
                            ProductTypeID = new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("83caa4e4-172d-4119-9fd5-4f6143be29dc"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "dbc876manu@gmail.com",
                            Name = "家電製造商SSA",
                            Phone = "0989373147",
                            ProductTypeID = new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("b5c2be42-c211-47aa-8c29-949f5d1cff08"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "as542bcmanu@gmail.com",
                            Name = "食品製造商SQA",
                            Phone = "0955823845",
                            ProductTypeID = new Guid("5903e594-a661-495f-a6ac-3855407b57a4"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("3553dba2-3e1f-4c43-a319-9f95bb3bc052"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "ab542cemanu@gmail.com",
                            Name = "3C製造商FSDA",
                            Phone = "0954688943",
                            ProductTypeID = new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("855be641-a527-4c6e-bd00-cd7c29cb84cc"),
                            CreateTime = new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified),
                            Email = "dbc572manu@gmail.com",
                            Name = "家電製造商QADA",
                            Phone = "0986983147",
                            ProductTypeID = new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.ImportRecord", b =>
                {
                    b.HasOne("e_Shop_Demo.Entities.Product", "Product")
                        .WithMany("ImportRecords")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.Product", b =>
                {
                    b.HasOne("e_Shop_Demo.Entities.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.PurchaseDetailRecord", b =>
                {
                    b.HasOne("e_Shop_Demo.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Shop_Demo.Entities.PurchaseRecord", "PurchaseRecord")
                        .WithMany("PurchaseDetailRecords")
                        .HasForeignKey("PurchaseRecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.PurchaseRecord", b =>
                {
                    b.HasOne("e_Shop_Demo.Entities.Customer", "Customer")
                        .WithMany("PurchaseRecords")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("e_Shop_Demo.Entities.Supplier", b =>
                {
                    b.HasOne("e_Shop_Demo.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}