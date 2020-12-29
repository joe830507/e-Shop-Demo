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
                name: "PurchaseDetailRecord",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PurchaseRecordId = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    CurrentPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailRecord_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "ID", "Account", "Activate", "BirthDate", "CreateTime", "Password", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("8dd56f23-ea02-43c8-835a-369efd4c44bf"), "jackson@example.com", true, new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8fbcabd-3d47-439c-a9e2-47a09f0f8d75"), "jdsaon@example.com", true, new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("392bdc2c-043c-4df0-afc6-667b46208c2f"), "jdsao123n@example.com", true, new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("df5c71b1-3802-4057-8927-3c28272b70ce"), "jdsao123n@example.com", true, new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0226eaae-6d0b-4c59-980d-32f654d8adcb"), "s4d5623n@example.com", true, new DateTime(1965, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ca8a9c7-faa4-42db-94d7-3237f2f71091"), "fsado123n@example.com", true, new DateTime(1952, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a4316b1-abbc-44a2-89e6-71601e895f67"), "gds45dn@example.com", true, new DateTime(1966, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d81a36f0-b13e-4c08-8e13-1327bf34ea2f"), "dsad4923n@example.com", true, new DateTime(2000, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f909c51a-042f-40f1-9749-c7e83bf4a3a6"), "s46asdn@example.com", true, new DateTime(1989, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Activate", "CreateTime", "Password", "Role", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("8e65a9ea-5c5d-4de6-b7cf-1910fbc49575"), "gsasdad46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("066ec126-6a28-4e5f-9eb6-e95b574eb9c7"), "gsas8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74062f3e-1b8b-4988-99a8-6c7aec4b195f"), "saad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("915fdf68-9fc3-447d-871b-52f5a871c72f"), "gsaasd55456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae38e44f-5b4b-419e-aca0-5e280aac0eff"), "gs49456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0266d670-8b08-40a9-ae92-65756c156185"), "gsad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9fe339d1-9da1-4a53-b26f-91724fcb1d08"), "general123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("51af0c49-38b0-4e44-b140-e8340bd15a0b"), "gene45656@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb18c2eb-3450-4f67-a3b5-ed2870c89d54"), "general456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1d59fd1-b027-44af-a397-ebc10accf67f"), "a22s8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22310594-a2da-4ec6-9979-95ef65d7d9c9"), "manager123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca5b8afd-05e9-4b1c-a9d6-06a4cd5143ac"), "admin123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10c8c9dd-f77a-4462-934c-0e6fec693f92"), "gendsa456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ImportRecord",
                columns: new[] { "ID", "CreateTime", "ImportPrice", "ProductID", "Quantity", "Status", "SupplierID" },
                values: new object[,]
                {
                    { new Guid("5075a558-0e10-426d-9a36-35ab8b137820"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 600.0, new Guid("435948e9-1d67-4757-86e9-fe97d48894b5"), 30, 1, new Guid("e2f50571-dab4-4c65-b2da-b0fb70accbfc") },
                    { new Guid("bebad55b-c577-4921-8e1e-8520d9ba53b2"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 5000.0, new Guid("22b6222f-cd49-46b4-a5de-2e08cfdf5697"), 20, 1, new Guid("eb04df6c-50da-430b-8660-16eba3399c0f") },
                    { new Guid("c860218d-774e-41bd-ac53-56c32cee0cf7"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 20.0, new Guid("98d1a3c7-b440-4a25-b8d6-a3872394fc34"), 100, 1, new Guid("5b733ea1-af3c-49f3-8a06-7074b5999296") }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreateTime", "Description", "Name", "PictureLink", "Price", "Quantity", "Type", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("98d1a3c7-b440-4a25-b8d6-a3872394fc34"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽", "洋芋片", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/640px-Potato-Chips.jpg", 30.0, 100, new Guid("c4a7cd61-f4e3-4ce9-b56b-55cf0608288f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22b6222f-cd49-46b4-a5de-2e08cfdf5697"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "從夜生活到風景照，都能拍得出色； W810 具備可讓您輕鬆拍出清晰精彩相片與 HD 影片的多項功能。6x 光學變焦可讓您拍出細節豐富的特寫相片，派對模式則可讓您輕鬆捕捉精彩夜生活。", "相機", "https://s.yimg.com/zp/images/F84200C57BFF5B8FB763B09688523E28F99D17E3", 9999.0, 20, new Guid("4733c6cd-1b16-40ba-a0f7-11e8b4f14201"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("435948e9-1d67-4757-86e9-fe97d48894b5"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "高滲透奈米水離子水分產量提升1800%;礦物負離子出口角度改變效果更集中", "吹風機", "https://johnlewis.scene7.com/is/image/JohnLewis/237876949", 999.0, 30, new Guid("9c27e7ab-fd09-4057-afa6-3bd589a7856b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("c4a7cd61-f4e3-4ce9-b56b-55cf0608288f"), "Food", 1 },
                    { new Guid("4733c6cd-1b16-40ba-a0f7-11e8b4f14201"), "Electronic", 2 },
                    { new Guid("9c27e7ab-fd09-4057-afa6-3bd589a7856b"), "Home_Appliances", 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseDetailRecord",
                columns: new[] { "ID", "CurrentPrice", "CustomerID", "ProductID", "PurchaseRecordId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7823b830-e85b-4cd2-bd2d-ad8dc128bd42"), 30.0, null, new Guid("98d1a3c7-b440-4a25-b8d6-a3872394fc34"), new Guid("37be978c-76c8-469f-8db0-41141e017622"), 5 },
                    { new Guid("d0cb6c37-fcb3-409b-bf50-3f7a1008b0f5"), 9999.0, null, new Guid("22b6222f-cd49-46b4-a5de-2e08cfdf5697"), new Guid("37be978c-76c8-469f-8db0-41141e017622"), 1 },
                    { new Guid("95d51292-fbbe-4fe5-8c19-2478fd87ca7b"), 999.0, null, new Guid("435948e9-1d67-4757-86e9-fe97d48894b5"), new Guid("37be978c-76c8-469f-8db0-41141e017622"), 1 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseRecord",
                columns: new[] { "ID", "CreateTime", "CustomerID", "PurchaseDate", "Total" },
                values: new object[] { new Guid("37be978c-76c8-469f-8db0-41141e017622"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8dd56f23-ea02-43c8-835a-369efd4c44bf"), new DateTime(2020, 12, 16, 15, 12, 30, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "ID", "CreateTime", "Email", "Name", "Phone", "ProductType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("75d50638-9d64-4bbf-ae55-ea8c72cbff4c"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as542bcmanu@gmail.com", "食品製造商SQA", "0955823845", new Guid("c4a7cd61-f4e3-4ce9-b56b-55cf0608288f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a21bff09-3d54-4956-abb3-c70aa1983908"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc876manu@gmail.com", "家電製造商SSA", "0989373147", new Guid("9c27e7ab-fd09-4057-afa6-3bd589a7856b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e471cfa3-8c5d-4976-9d26-9333ef989714"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as432bcemanu@gmail.com", "3C製造商ASDW", "0958578943", new Guid("4733c6cd-1b16-40ba-a0f7-11e8b4f14201"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d84d19ae-b5fb-4d18-919b-b9ca8645def3"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sadabcmanu@gmail.com", "食品製造商CCC", "0912123845", new Guid("c4a7cd61-f4e3-4ce9-b56b-55cf0608288f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("208f4e1a-9d60-4a3e-a0d6-6f411592d87c"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "aasdbcmanu@gmail.com", "家電製造商SDDDA", "0989546547", new Guid("9c27e7ab-fd09-4057-afa6-3bd589a7856b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b733ea1-af3c-49f3-8a06-7074b5999296"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcmanu@gmail.com", "食品製造商A", "0956123845", new Guid("c4a7cd61-f4e3-4ce9-b56b-55cf0608288f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c82b7e0-b56f-4e1c-916f-bfc9e155d78b"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sabcmanu@gmail.com", "食品製造商C", "0956185845", new Guid("c4a7cd61-f4e3-4ce9-b56b-55cf0608288f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2f50571-dab4-4c65-b2da-b0fb70accbfc"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbcmanu@gmail.com", "家電製造商A", "0989543147", new Guid("9c27e7ab-fd09-4057-afa6-3bd589a7856b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb04df6c-50da-430b-8660-16eba3399c0f"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcemanu@gmail.com", "3C製造商A", "0954778943", new Guid("4733c6cd-1b16-40ba-a0f7-11e8b4f14201"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63871d42-a1b1-477d-a9fb-fe8624e874a0"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ab542cemanu@gmail.com", "3C製造商FSDA", "0954688943", new Guid("4733c6cd-1b16-40ba-a0f7-11e8b4f14201"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ba747a1-ad15-41a6-a9b0-ec153ed1ca75"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ssaabcemanu@gmail.com", "3C製造商DDD", "0974778943", new Guid("4733c6cd-1b16-40ba-a0f7-11e8b4f14201"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa6e8aa0-2b9b-4038-b72b-93b21f9110be"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc572manu@gmail.com", "家電製造商QADA", "0986983147", new Guid("9c27e7ab-fd09-4057-afa6-3bd589a7856b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailRecord_CustomerID",
                table: "PurchaseDetailRecord",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ImportRecord");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "PurchaseDetailRecord");

            migrationBuilder.DropTable(
                name: "PurchaseRecord");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
