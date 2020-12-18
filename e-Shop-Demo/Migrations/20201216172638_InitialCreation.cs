using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Shop_Demo.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Activate = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Activate = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ImportRecord",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    SupplierID = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ImportPrice = table.Column<double>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportRecord", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailRecord",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PurchaseRecordId = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    CurrentPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailRecord", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRecord",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRecord", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "ID", "Account", "Activate", "BirthDate", "CreateTime", "Password", "UpdateTime" },
                values: new object[] { new Guid("398023d9-920b-4c27-8f34-00f2bf345100"), "jackson@example.com", false, new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "_ohjrsvt7bACcAHjb-29hGG7EbXZ1QErLxXHXZMQrPQ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Activate", "CreateTime", "Password", "UpdateTime" },
                values: new object[] { new Guid("e0348ec1-1881-457e-a73f-06910fd306e2"), "manager123@example.com", false, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C_d2jNWFZ_WvEoOoXMpvXdydnpRQ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ImportRecord",
                columns: new[] { "ID", "CreateTime", "ImportPrice", "ProductID", "Quantity", "SupplierID" },
                values: new object[,]
                {
                    { new Guid("e402d783-521e-4bf2-a472-a1d9dd1ee16a"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 20.0, new Guid("242fcdb9-4269-4be7-a8d5-635993d32f59"), 100, new Guid("cd0560d4-2881-4f49-a08a-1e12c9cddd38") },
                    { new Guid("1774a47f-c34b-4158-a54c-a795a0b6590c"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 5000.0, new Guid("b0400f04-c7a4-4f0e-85ed-b2c8e20e77e2"), 20, new Guid("b11c3daf-d781-4c0c-97d8-280e6f5c11c5") },
                    { new Guid("f6a384d0-75ec-4f85-91ab-6ebcefbdad2e"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 600.0, new Guid("69e2668e-a5fd-4f90-9021-47dda501c216"), 30, new Guid("29282b01-7c53-44e2-a667-2e9a5588e659") }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreateTime", "Name", "Price", "Quantity", "Type", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("242fcdb9-4269-4be7-a8d5-635993d32f59"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Potato Chips", 30.0, 100, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0400f04-c7a4-4f0e-85ed-b2c8e20e77e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Camera", 9999.0, 20, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69e2668e-a5fd-4f90-9021-47dda501c216"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hair Dryer", 999.0, 30, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PurchaseDetailRecord",
                columns: new[] { "ID", "CurrentPrice", "ProductID", "PurchaseRecordId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2ae95acc-4397-4994-8118-3cd184ab968f"), 30.0, new Guid("242fcdb9-4269-4be7-a8d5-635993d32f59"), new Guid("7fe814a6-449e-4161-a5ab-073736ae584b"), 5 },
                    { new Guid("d2288737-858e-4e43-8361-f3eac5787a5e"), 9999.0, new Guid("b0400f04-c7a4-4f0e-85ed-b2c8e20e77e2"), new Guid("7fe814a6-449e-4161-a5ab-073736ae584b"), 1 },
                    { new Guid("0958c47c-32a1-468e-a778-556fff94fed1"), 999.0, new Guid("69e2668e-a5fd-4f90-9021-47dda501c216"), new Guid("7fe814a6-449e-4161-a5ab-073736ae584b"), 1 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseRecord",
                columns: new[] { "ID", "CreateTime", "CustomerID", "PurchaseDate", "Total" },
                values: new object[] { new Guid("7fe814a6-449e-4161-a5ab-073736ae584b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("398023d9-920b-4c27-8f34-00f2bf345100"), new DateTime(2020, 12, 16, 15, 12, 30, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "ID", "CreateTime", "Name", "Phone", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("cd0560d4-2881-4f49-a08a-1e12c9cddd38"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "Food Manufacturer A", "0956123845", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b11c3daf-d781-4c0c-97d8-280e6f5c11c5"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "3C Manufacturer A", "0954778943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("29282b01-7c53-44e2-a667-2e9a5588e659"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "HairDryer Manufacturer A", "0989543147", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ImportRecord");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PurchaseDetailRecord");

            migrationBuilder.DropTable(
                name: "PurchaseRecord");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
