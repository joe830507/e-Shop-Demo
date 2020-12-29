using e_Shop_Demo.Enums;
using e_Shop_Demo.Utilities;
using Microsoft.EntityFrameworkCore;
using System;

namespace e_Shop_Demo.Entities
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var now = new DateTime(2020, 12, 16, 13, 12, 30);
            Employee[] employees = new Employee[] {
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "admin123@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Admin
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "manager123@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Manager
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "general123@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.General
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "general456@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.General
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "gene45656@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Admin
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "gendsa456@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Manager
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "gsad5456@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Admin
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "gs49456@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Manager
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "gsaasd55456@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.General
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "saad5456@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Admin
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "gsas8d46@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Manager
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "gsasdad46@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Manager
                },
                new Employee
                {
                    ID = Guid.NewGuid(),
                    Account = "a22s8d46@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now,
                    Activate = true,
                    Role = (int)Role.Manager
                }
            };
            Customer[] customers = new Customer[]
            {
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "jackson@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(1985,2,13),
                    Activate = true,
                    CreateTime = now
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "jdsaon@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(1994,5,29),
                    Activate = true,
                    CreateTime = now
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "jdsao123n@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(1995,7,3),
                    Activate = true,
                    CreateTime = now
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "jdsao123n@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(1977,11,15),
                    Activate = true,
                    CreateTime = now
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "s4d5623n@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(1965,1,30),
                    Activate = true,
                    CreateTime = now
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "fsado123n@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(1952,3,3),
                    Activate = true,
                    CreateTime = now
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "gds45dn@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(1966,9,14),
                    Activate = true,
                    CreateTime = now
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "dsad4923n@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(2000,10,31),
                    Activate = true,
                    CreateTime = now
                },
                new Customer
                {
                    ID = Guid.NewGuid(),
                    Account = "s46asdn@example.com",
                    Password = SHA256Utility.Encode("jackson123"),
                    BirthDate = new DateTime(1989,4,19),
                    Activate = true,
                    CreateTime = now
                }
            };
            ProductType[] productTypes = new ProductType[]
            {
                new ProductType
                {
                    ID = Guid.NewGuid(),
                    Name = "食品",
                    Order = 1
                },
                new ProductType
                {
                    ID = Guid.NewGuid(),
                    Name = "消費性電子產品",
                    Order = 2
                },
                new ProductType
                {
                    ID = Guid.NewGuid(),
                    Name = "家電",
                    Order = 3
                },
            };
            Supplier[] suppliers = new Supplier[]
            {
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "食品製造商A",
                    Phone = "0956123845",
                    Email = "abcmanu@gmail.com",
                    ProductType = productTypes[0].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "3C製造商A",
                    Phone = "0954778943",
                    Email = "abcemanu@gmail.com",
                    ProductType = productTypes[1].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "家電製造商A",
                    Phone = "0989543147",
                    Email = "dbcmanu@gmail.com",
                    ProductType = productTypes[2].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "食品製造商C",
                    Phone = "0956185845",
                    Email = "sabcmanu@gmail.com",
                    ProductType = productTypes[0].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "3C製造商DDD",
                    Phone = "0974778943",
                    Email = "ssaabcemanu@gmail.com",
                    ProductType = productTypes[1].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "家電製造商SDDDA",
                    Phone = "0989546547",
                    Email = "aasdbcmanu@gmail.com",
                    ProductType = productTypes[2].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "食品製造商CCC",
                    Phone = "0912123845",
                    Email = "sadabcmanu@gmail.com",
                    ProductType = productTypes[0].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "3C製造商ASDW",
                    Phone = "0958578943",
                    Email = "as432bcemanu@gmail.com",
                    ProductType = productTypes[1].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "家電製造商SSA",
                    Phone = "0989373147",
                    Email = "dbc876manu@gmail.com",
                    ProductType = productTypes[2].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "食品製造商SQA",
                    Phone = "0955823845",
                    Email = "as542bcmanu@gmail.com",
                    ProductType = productTypes[0].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "3C製造商FSDA",
                    Phone = "0954688943",
                    Email = "ab542cemanu@gmail.com",
                    ProductType = productTypes[1].ID,
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "家電製造商QADA",
                    Phone = "0986983147",
                    Email = "dbc572manu@gmail.com",
                    ProductType = productTypes[2].ID,
                    CreateTime = now
                }
            };
            Product[] products = new Product[]
            {
                new Product{
                    ID = Guid.NewGuid(),
                    Name = "洋芋片",
                    Price = 30,
                    Quantity = 100,
                    Type = productTypes[0].ID,
                    Description = "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽",
                    PictureLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/640px-Potato-Chips.jpg",
                    CreateTime = now
                },
                new Product{
                    ID = Guid.NewGuid(),
                    Name = "相機",
                    Price = 9999,
                    Quantity = 20,
                    Type = productTypes[1].ID,
                    Description = "從夜生活到風景照，都能拍得出色； W810 具備可讓您輕鬆拍出清晰精彩相片與 HD 影片的多項功能。6x 光學變焦可讓您拍出細節豐富的特寫相片，派對模式則可讓您輕鬆捕捉精彩夜生活。",
                    PictureLink = "https://s.yimg.com/zp/images/F84200C57BFF5B8FB763B09688523E28F99D17E3",
                    CreateTime = now
                },
                new Product{
                    ID = Guid.NewGuid(),
                    Name = "吹風機",
                    Price = 999,
                    Quantity = 30,
                    Type = productTypes[2].ID,
                    Description = "高滲透奈米水離子水分產量提升1800%;礦物負離子出口角度改變效果更集中",
                    PictureLink = "https://johnlewis.scene7.com/is/image/JohnLewis/237876949",
                    CreateTime = now
                }
            };
            ImportRecord[] importRecords = new ImportRecord[]
            {
                new ImportRecord
                {
                    ID = Guid.NewGuid(),
                    ProductID = products[0].ID,
                    SupplierID = suppliers[0].ID,
                    Quantity = 100,
                    ImportPrice = 20,
                    Status = 1,
                    CreateTime = now
                },
                new ImportRecord
                {
                    ID = Guid.NewGuid(),
                    ProductID = products[1].ID,
                    SupplierID = suppliers[1].ID,
                    Quantity = 20,
                    ImportPrice = 5000,
                    Status = 1,
                    CreateTime = now
                },
                new ImportRecord
                {
                    ID = Guid.NewGuid(),
                    ProductID = products[2].ID,
                    SupplierID = suppliers[2].ID,
                    Quantity = 30,
                    ImportPrice = 600,
                    Status = 1,
                    CreateTime = now
                }
            };
            PurchaseRecord[] purchaseRecords = new PurchaseRecord[]
            {
                new PurchaseRecord
                {
                    ID = Guid.NewGuid(),
                    CustomerID = customers[0].ID,
                    PurchaseDate = now.AddHours(2)
                }
            };
            PurchaseDetailRecord[] purchaseDetailRecords = new PurchaseDetailRecord[]
            {
                new PurchaseDetailRecord
                {
                    ID = Guid.NewGuid(),
                    PurchaseRecordId = purchaseRecords[0].ID,
                    ProductID = products[0].ID,
                    CurrentPrice = products[0].Price,
                    Quantity = 5
                },
                new PurchaseDetailRecord
                {
                    ID = Guid.NewGuid(),
                    PurchaseRecordId = purchaseRecords[0].ID,
                    ProductID = products[1].ID,
                    CurrentPrice = products[1].Price,
                    Quantity = 1
                },
                new PurchaseDetailRecord
                {
                    ID = Guid.NewGuid(),
                    PurchaseRecordId = purchaseRecords[0].ID,
                    ProductID = products[2].ID,
                    CurrentPrice = products[2].Price,
                    Quantity = 1
                }
            };
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<Supplier>().HasData(suppliers);
            modelBuilder.Entity<ProductType>().HasData(productTypes);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ImportRecord>().HasData(importRecords);
            modelBuilder.Entity<PurchaseRecord>().HasData(purchaseRecords);
            modelBuilder.Entity<PurchaseDetailRecord>().HasData(purchaseDetailRecords);
        }
    }
}
