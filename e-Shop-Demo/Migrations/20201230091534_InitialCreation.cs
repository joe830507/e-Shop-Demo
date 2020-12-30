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
                    Role = table.Column<int>(nullable: false),
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
                    Status = table.Column<int>(nullable: false),
                    ImportPrice = table.Column<double>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
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
                    Type = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PictureLink = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ProductType = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
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
                    table.ForeignKey(
                        name: "FK_PurchaseRecord_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailRecord",
                columns: table => new
                {
                    PurchaseRecordID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    CurrentPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailRecord", x => new { x.PurchaseRecordID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_PurchaseDetailRecord_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailRecord_PurchaseRecord_PurchaseRecordID",
                        column: x => x.PurchaseRecordID,
                        principalTable: "PurchaseRecord",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "ID", "Account", "Activate", "BirthDate", "CreateTime", "Password", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("31bb2dea-35cd-4a52-80af-2df191b2ded8"), "jackson@example.com", true, new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("088e97bb-4483-442e-a9bc-c7c4c9474ea7"), "jdsaon@example.com", true, new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f878b1d1-d60c-4d51-9624-82483634e4e3"), "jdsao123n@example.com", true, new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a244980-1b4e-43a7-b888-74f44960df0f"), "jdsao123n@example.com", true, new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1a16359c-57a6-4a9d-b097-90d3b9ee8cb5"), "s4d5623n@example.com", true, new DateTime(1965, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e64bfb39-9867-4623-8f71-f639bb7c39f5"), "fsado123n@example.com", true, new DateTime(1952, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a841d65-2ef5-4964-a552-659f2cd4bbe7"), "gds45dn@example.com", true, new DateTime(1966, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("09a41afe-959e-45eb-bae6-b34d8785d367"), "dsad4923n@example.com", true, new DateTime(2000, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5fad7a63-4d12-4994-9eb9-3894ddd40eb2"), "s46asdn@example.com", true, new DateTime(1989, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Activate", "CreateTime", "Password", "Role", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("4a460441-c48d-4548-bea7-d4a7dbea02cc"), "gsasdad46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d821b9b4-b563-4a1a-a8c8-8c79621a33b5"), "gsas8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c9ae280-8d73-42ae-8f47-91587596c0e7"), "saad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("58caa7ec-8cec-4a23-a353-bbc49f1088ab"), "gsaasd55456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db794898-a7ce-4d90-ade8-314d6bd31630"), "gs49456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6583897-47bb-41b4-830f-4f95b16e5970"), "gsad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("303bc117-302f-46d9-b6f9-104c63a24379"), "a22s8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5fa0766-9180-4d4f-8fdf-c98ccebfed9a"), "gene45656@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ce661c2-47e0-492d-b440-3737f7bd932c"), "general456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5809f84-e1c7-4f82-bea0-e1cdd2c870c5"), "general123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3884a645-5ca9-46a5-81d1-69cd749d3be9"), "manager123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e351ab0b-4a9a-40f7-a1d5-da76f1876043"), "admin123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a47fde50-725f-4954-a0f6-28786c97498b"), "gendsa456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ImportRecord",
                columns: new[] { "ID", "CreateTime", "ImportPrice", "ProductID", "Quantity", "Status", "SupplierID", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("452baa0a-ec45-4465-8d54-7084104641fc"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 20.0, new Guid("6bc7c44b-6158-4c0b-9ced-80c2ae7cd4e9"), 100, 1, new Guid("781ece8e-e2c0-4995-91c1-4e2a482f9b56"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89fea79e-d8b1-48f5-89b5-0c0c9668060a"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 5000.0, new Guid("2e814d19-1795-4e78-9f15-b92397de5343"), 20, 1, new Guid("c8425073-4499-45b7-9f80-75e7fdd07380"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("01b24651-8d3f-4525-bbfa-0e01eb011049"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 600.0, new Guid("1660fa32-b29a-487f-a755-7e7bfc423b68"), 30, 1, new Guid("bb20b1e5-7b3a-4bac-a24e-32d01f406046"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreateTime", "Description", "Name", "PictureLink", "Price", "Quantity", "Type", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("6bc7c44b-6158-4c0b-9ced-80c2ae7cd4e9"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽", "洋芋片", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/640px-Potato-Chips.jpg", 30.0, 100, new Guid("b8a34d4f-4822-4375-a1cc-e5e9660b6178"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e814d19-1795-4e78-9f15-b92397de5343"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "從夜生活到風景照，都能拍得出色； W810 具備可讓您輕鬆拍出清晰精彩相片與 HD 影片的多項功能。6x 光學變焦可讓您拍出細節豐富的特寫相片，派對模式則可讓您輕鬆捕捉精彩夜生活。", "相機", "https://s.yimg.com/zp/images/F84200C57BFF5B8FB763B09688523E28F99D17E3", 9999.0, 20, new Guid("3a50bae7-2ff0-4fcc-9607-8da4fb6c5911"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1660fa32-b29a-487f-a755-7e7bfc423b68"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "高滲透奈米水離子水分產量提升1800%;礦物負離子出口角度改變效果更集中", "吹風機", "https://johnlewis.scene7.com/is/image/JohnLewis/237876949", 999.0, 30, new Guid("9da8ad35-c08d-4017-b3a6-4ee6556f3c6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("9da8ad35-c08d-4017-b3a6-4ee6556f3c6f"), "家電", 3 },
                    { new Guid("3a50bae7-2ff0-4fcc-9607-8da4fb6c5911"), "消費性電子產品", 2 },
                    { new Guid("b8a34d4f-4822-4375-a1cc-e5e9660b6178"), "食品", 1 }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "ID", "CreateTime", "Email", "Name", "Phone", "ProductType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("7cfeae85-a626-48dc-8f28-7c9a5b04b5b7"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ab542cemanu@gmail.com", "3C製造商FSDA", "0954688943", new Guid("3a50bae7-2ff0-4fcc-9607-8da4fb6c5911"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("781ece8e-e2c0-4995-91c1-4e2a482f9b56"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcmanu@gmail.com", "食品製造商A", "0956123845", new Guid("b8a34d4f-4822-4375-a1cc-e5e9660b6178"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8425073-4499-45b7-9f80-75e7fdd07380"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcemanu@gmail.com", "3C製造商A", "0954778943", new Guid("3a50bae7-2ff0-4fcc-9607-8da4fb6c5911"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb20b1e5-7b3a-4bac-a24e-32d01f406046"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbcmanu@gmail.com", "家電製造商A", "0989543147", new Guid("9da8ad35-c08d-4017-b3a6-4ee6556f3c6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2662ac68-e541-4032-a145-89a75d9440bd"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sabcmanu@gmail.com", "食品製造商C", "0956185845", new Guid("b8a34d4f-4822-4375-a1cc-e5e9660b6178"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("77e5efc1-1ae0-4c62-9cfe-04b7721b959f"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ssaabcemanu@gmail.com", "3C製造商DDD", "0974778943", new Guid("3a50bae7-2ff0-4fcc-9607-8da4fb6c5911"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7308753-57bf-4440-92ae-8aae9e4dcb0a"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "aasdbcmanu@gmail.com", "家電製造商SDDDA", "0989546547", new Guid("9da8ad35-c08d-4017-b3a6-4ee6556f3c6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1863c737-3f4c-4eee-a4b7-93329690cbc6"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sadabcmanu@gmail.com", "食品製造商CCC", "0912123845", new Guid("b8a34d4f-4822-4375-a1cc-e5e9660b6178"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("096bbe3e-84bd-4e5b-945c-68cae7c971c9"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as432bcemanu@gmail.com", "3C製造商ASDW", "0958578943", new Guid("3a50bae7-2ff0-4fcc-9607-8da4fb6c5911"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f7a2f68-91fb-496d-b362-84858a51e500"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc876manu@gmail.com", "家電製造商SSA", "0989373147", new Guid("9da8ad35-c08d-4017-b3a6-4ee6556f3c6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f06fc7e-4f83-49ec-9183-4f9692350221"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as542bcmanu@gmail.com", "食品製造商SQA", "0955823845", new Guid("b8a34d4f-4822-4375-a1cc-e5e9660b6178"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b6640aa-09b1-4577-ab33-1458b6741b20"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc572manu@gmail.com", "家電製造商QADA", "0986983147", new Guid("9da8ad35-c08d-4017-b3a6-4ee6556f3c6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PurchaseRecord",
                columns: new[] { "ID", "CreateTime", "CustomerID", "PurchaseDate", "Total" },
                values: new object[] { new Guid("b994f61b-6498-4893-abed-eb20579f42ea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("31bb2dea-35cd-4a52-80af-2df191b2ded8"), new DateTime(2020, 12, 16, 15, 12, 30, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "PurchaseDetailRecord",
                columns: new[] { "PurchaseRecordID", "ProductID", "CurrentPrice", "Quantity" },
                values: new object[] { new Guid("b994f61b-6498-4893-abed-eb20579f42ea"), new Guid("6bc7c44b-6158-4c0b-9ced-80c2ae7cd4e9"), 30.0, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailRecord_ProductID",
                table: "PurchaseDetailRecord",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRecord_CustomerID",
                table: "PurchaseRecord",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ImportRecord");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "PurchaseDetailRecord");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PurchaseRecord");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
