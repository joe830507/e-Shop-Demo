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
                    Account = "manager123@example.com",
                    Password = SHA256Utility.Encode("qweasd1234"),
                    CreateTime = now
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
                    Activate = false,
                    CreateTime = now
                }
            };
            Supplier[] suppliers = new Supplier[]
            {
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "Food Manufacturer A",
                    Phone = "0956123845",
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "3C Manufacturer A",
                    Phone = "0954778943",
                    CreateTime = now
                },
                new Supplier
                {
                    ID = Guid.NewGuid(),
                    Name = "HairDryer Manufacturer A",
                    Phone = "0989543147",
                    CreateTime = now
                }
            };
            ProductType[] productTypes = new ProductType[]
            {
                new ProductType
                {
                    ID = Guid.NewGuid(),
                    Name = "Food",
                    Order = 1
                },
                new ProductType
                {
                    ID = Guid.NewGuid(),
                    Name = "Electronic",
                    Order = 2
                },
                new ProductType
                {
                    ID = Guid.NewGuid(),
                    Name = "Home_Appliances",
                    Order = 3
                },
            };
            Product[] products = new Product[]
            {
                new Product{
                    ID = Guid.NewGuid(),
                    Name = "Potato Chips",
                    Price = 30,
                    Quantity = 100,
                    Type = productTypes[0].ID
                },
                new Product{
                    ID = Guid.NewGuid(),
                    Name = "Camera",
                    Price = 9999,
                    Quantity = 20,
                    Type = productTypes[1].ID
                },
                new Product{
                    ID = Guid.NewGuid(),
                    Name = "Hair Dryer",
                    Price = 999,
                    Quantity = 30,
                    Type = productTypes[2].ID
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
                    CreateTime = now
                },
                new ImportRecord
                {
                    ID = Guid.NewGuid(),
                    ProductID = products[1].ID,
                    SupplierID = suppliers[1].ID,
                    Quantity = 20,
                    ImportPrice = 5000,
                    CreateTime = now
                },
                new ImportRecord
                {
                    ID = Guid.NewGuid(),
                    ProductID = products[2].ID,
                    SupplierID = suppliers[2].ID,
                    Quantity = 30,
                    ImportPrice = 600,
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
