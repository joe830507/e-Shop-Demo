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
                    table.ForeignKey(
                        name: "FK_PurchaseRecord_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductTypeID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PictureLink = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ProductTypeID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Supplier_ProductType_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_ImportRecord_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
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
                    { new Guid("16fbe29c-4d9c-4f6a-98e8-7e22ca822efe"), "jackson@example.com", true, new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1bd1f47-b8bf-4640-9024-890afe394112"), "jdsaon@example.com", true, new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e4dedf2-cde2-46af-a1b7-726ab4d86c31"), "jdsao123n@example.com", true, new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30d31269-90da-4971-bcdb-9f0dafb92dc2"), "jdsao123n@example.com", true, new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dca13509-c8e2-44fb-85be-7f923f596470"), "s4d5623n@example.com", true, new DateTime(1965, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d47b22f-8f13-4f2c-8f87-91064ac98cb3"), "fsado123n@example.com", true, new DateTime(1952, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21364f8f-2bcb-4e77-b3ff-46af566bc8c1"), "gds45dn@example.com", true, new DateTime(1966, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b7fedf4-26c2-49aa-a2dd-a65308fad9cb"), "dsad4923n@example.com", true, new DateTime(2000, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7250e69c-595c-498e-a922-826a4d3d05d2"), "s46asdn@example.com", true, new DateTime(1989, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Activate", "CreateTime", "Password", "Role", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("26238d9e-4648-43f4-943d-b9c65e70fa0e"), "a22s8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb8a7818-4e67-4ee7-840c-530c136137dd"), "gsasdad46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f92e052-266c-437e-8825-ae73b0209e59"), "gsas8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("35eaa279-50ea-47d8-b885-2fd002210c80"), "saad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("53f5fb33-e20e-441e-8620-7ec41c0107ac"), "gsaasd55456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de1186bb-f1c7-4f30-9ea1-ce48a6fff690"), "gs49456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd8d2c18-fabd-4c3c-8cc4-7d9890320401"), "general456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c79b4ce0-5cfc-4060-9d80-ace62017bd36"), "gendsa456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59895b6b-1eff-4a32-9da4-fd04817d6970"), "gene45656@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("45445a72-c94e-4c78-82cd-70fc602b0200"), "general123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2a0468a-fe8e-4903-b4e6-4268695cc2b8"), "manager123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5acd1e3-2fa1-48b8-b480-0399b590d8d8"), "admin123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc02ca5c-b36f-4cf7-a12e-6d317b40b8e9"), "gsad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"), "消費性電子產品", 2 },
                    { new Guid("5903e594-a661-495f-a6ac-3855407b57a4"), "食品", 1 },
                    { new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"), "家電", 3 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreateTime", "Description", "Name", "PictureLink", "Price", "ProductTypeID", "Quantity", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("5a17c4dc-90ea-4317-8cd5-1c07909d14aa"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽", "洋芋片", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/640px-Potato-Chips.jpg", 30.0, new Guid("5903e594-a661-495f-a6ac-3855407b57a4"), 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b2a7372-94c6-4f73-b004-93632c134a07"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "從夜生活到風景照，都能拍得出色； W810 具備可讓您輕鬆拍出清晰精彩相片與 HD 影片的多項功能。6x 光學變焦可讓您拍出細節豐富的特寫相片，派對模式則可讓您輕鬆捕捉精彩夜生活。", "相機", "https://s.yimg.com/zp/images/F84200C57BFF5B8FB763B09688523E28F99D17E3", 9999.0, new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("48536da9-0218-41d1-92a4-1389070051d4"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "高滲透奈米水離子水分產量提升1800%;礦物負離子出口角度改變效果更集中", "吹風機", "https://johnlewis.scene7.com/is/image/JohnLewis/237876949", 999.0, new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PurchaseRecord",
                columns: new[] { "ID", "CreateTime", "CustomerID", "PurchaseDate", "Total" },
                values: new object[] { new Guid("93ab91cb-9550-4772-90d9-19c7de95c89c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("16fbe29c-4d9c-4f6a-98e8-7e22ca822efe"), new DateTime(2020, 12, 16, 15, 12, 30, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "ID", "CreateTime", "Email", "Name", "Phone", "ProductTypeID", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("043e9678-524b-44fb-8f40-4e52633f0397"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcmanu@gmail.com", "食品製造商A", "0956123845", new Guid("5903e594-a661-495f-a6ac-3855407b57a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4ee255bd-fc22-4fa1-b948-96fd749898f3"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sabcmanu@gmail.com", "食品製造商C", "0956185845", new Guid("5903e594-a661-495f-a6ac-3855407b57a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c88e8f12-0cae-4ce9-9b10-9a6a8eec6d24"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sadabcmanu@gmail.com", "食品製造商CCC", "0912123845", new Guid("5903e594-a661-495f-a6ac-3855407b57a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c2be42-c211-47aa-8c29-949f5d1cff08"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as542bcmanu@gmail.com", "食品製造商SQA", "0955823845", new Guid("5903e594-a661-495f-a6ac-3855407b57a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3cbb5266-ccb1-47ec-8ae6-f32f6466998b"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcemanu@gmail.com", "3C製造商A", "0954778943", new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0f654fc-9c37-49c9-9055-50a5e4573726"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ssaabcemanu@gmail.com", "3C製造商DDD", "0974778943", new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb8d2769-91c8-491f-9cad-bd51a7cef63e"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as432bcemanu@gmail.com", "3C製造商ASDW", "0958578943", new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3553dba2-3e1f-4c43-a319-9f95bb3bc052"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ab542cemanu@gmail.com", "3C製造商FSDA", "0954688943", new Guid("17e8b849-5856-4e9d-93a7-ab6aa198846d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43fc0381-d505-4fd5-81e6-2faff33e0e48"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbcmanu@gmail.com", "家電製造商A", "0989543147", new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0174143b-d787-4ca6-8403-c47ab63ca685"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "aasdbcmanu@gmail.com", "家電製造商SDDDA", "0989546547", new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83caa4e4-172d-4119-9fd5-4f6143be29dc"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc876manu@gmail.com", "家電製造商SSA", "0989373147", new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("855be641-a527-4c6e-bd00-cd7c29cb84cc"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc572manu@gmail.com", "家電製造商QADA", "0986983147", new Guid("b0f764aa-a91a-4304-8b7a-81f21b97ee6a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ImportRecord",
                columns: new[] { "ID", "CreateTime", "ImportPrice", "ProductID", "Quantity", "Status", "SupplierID", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("a9242e42-b2ec-4af5-8171-9ff8d6881091"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 20.0, new Guid("5a17c4dc-90ea-4317-8cd5-1c07909d14aa"), 100, 1, new Guid("043e9678-524b-44fb-8f40-4e52633f0397"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f45b6f4-0d49-44a2-9d81-56358ba57d12"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 5000.0, new Guid("7b2a7372-94c6-4f73-b004-93632c134a07"), 20, 1, new Guid("3cbb5266-ccb1-47ec-8ae6-f32f6466998b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9e204a6c-f2ff-4ede-a716-cdb47963f7db"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 600.0, new Guid("48536da9-0218-41d1-92a4-1389070051d4"), 30, 1, new Guid("43fc0381-d505-4fd5-81e6-2faff33e0e48"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PurchaseDetailRecord",
                columns: new[] { "PurchaseRecordID", "ProductID", "CurrentPrice", "Quantity" },
                values: new object[] { new Guid("93ab91cb-9550-4772-90d9-19c7de95c89c"), new Guid("5a17c4dc-90ea-4317-8cd5-1c07909d14aa"), 30.0, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_ImportRecord_ProductID",
                table: "ImportRecord",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeID",
                table: "Product",
                column: "ProductTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailRecord_ProductID",
                table: "PurchaseDetailRecord",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRecord_CustomerID",
                table: "PurchaseRecord",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProductTypeID",
                table: "Supplier",
                column: "ProductTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ImportRecord");

            migrationBuilder.DropTable(
                name: "PurchaseDetailRecord");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PurchaseRecord");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
