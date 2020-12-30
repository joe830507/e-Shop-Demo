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
                    { new Guid("6e3f32e0-bbf9-4598-9b72-6c3bd8c7d29d"), "jackson@example.com", true, new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3647546-8611-43bd-9549-949d04e09751"), "jdsaon@example.com", true, new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e60945b4-42d0-498c-a33e-39f1d0603086"), "jdsao123n@example.com", true, new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5dd74d9a-cf67-44a7-b29b-f456002fd07b"), "jdsao123n@example.com", true, new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e385830a-c588-4914-b100-450bf41ef364"), "s4d5623n@example.com", true, new DateTime(1965, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5fb357fb-121a-4f31-8593-0900ab2f50cb"), "fsado123n@example.com", true, new DateTime(1952, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("81c56bf2-5e1f-4025-9a80-dd0cbc2f9347"), "gds45dn@example.com", true, new DateTime(1966, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7581d757-b741-4be5-bce0-105954312dd6"), "dsad4923n@example.com", true, new DateTime(2000, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f01a42b9-48a0-4388-8707-f90a3b1928eb"), "s46asdn@example.com", true, new DateTime(1989, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Activate", "CreateTime", "Password", "Role", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("c42cef66-200b-4358-bea6-841a5e498e68"), "gsasdad46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2b2287d-9498-43e0-9ce3-41aac61f3746"), "gsas8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("219b9189-8192-40a8-9b65-a73be00b8243"), "saad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8523279b-90a1-4579-8487-0a332b797f51"), "gsaasd55456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43f877c5-c622-4308-92a3-c286dae050f9"), "gs49456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc8712dc-19e1-4217-b564-e64678796a0c"), "gsad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4e8ee82-1ace-4223-81c2-ad2f4cf59312"), "general123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43a608eb-a3eb-4bd2-90f7-7073f544081a"), "gene45656@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa072816-79fd-4440-a519-35baad33a0c4"), "general456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7608cfc6-b85e-4db6-8d82-df005180ca40"), "a22s8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9195f123-7a78-405d-aa4e-478a02ed0990"), "manager123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d16662a0-4453-4c27-be53-b187798aad36"), "admin123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13473faf-db8f-425c-b57f-c289980b3506"), "gendsa456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ImportRecord",
                columns: new[] { "ID", "CreateTime", "ImportPrice", "ProductID", "Quantity", "Status", "SupplierID", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("3119b448-2c92-42be-acd6-008fcdc51ffc"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 600.0, new Guid("b9d09d92-4a5c-4648-a8a5-84927c973c1d"), 30, 1, new Guid("933cc821-bbb1-4c68-98eb-e27442b132c6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab92acbf-a18b-433b-9cf1-32ef55a57a9c"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 5000.0, new Guid("3313eeac-a801-46f2-a9d4-714f3b076485"), 20, 1, new Guid("ab075326-b646-42e7-9a22-d058119ab05d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12ac9d23-8d6c-430e-8e1b-5cbee4785448"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 20.0, new Guid("a42b877b-e470-49a9-83b4-ed98f1eeb62e"), 100, 1, new Guid("29f39392-1143-4fae-b624-0a7abc67d675"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreateTime", "Description", "Name", "PictureLink", "Price", "Quantity", "Type", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("a42b877b-e470-49a9-83b4-ed98f1eeb62e"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽", "洋芋片", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/640px-Potato-Chips.jpg", 30.0, 100, new Guid("b0fccd0e-b813-440d-bc79-e7e76f31de31"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3313eeac-a801-46f2-a9d4-714f3b076485"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "從夜生活到風景照，都能拍得出色； W810 具備可讓您輕鬆拍出清晰精彩相片與 HD 影片的多項功能。6x 光學變焦可讓您拍出細節豐富的特寫相片，派對模式則可讓您輕鬆捕捉精彩夜生活。", "相機", "https://s.yimg.com/zp/images/F84200C57BFF5B8FB763B09688523E28F99D17E3", 9999.0, 20, new Guid("ff669fe1-aaf2-432f-9be3-76c7bfba6492"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9d09d92-4a5c-4648-a8a5-84927c973c1d"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "高滲透奈米水離子水分產量提升1800%;礦物負離子出口角度改變效果更集中", "吹風機", "https://johnlewis.scene7.com/is/image/JohnLewis/237876949", 999.0, 30, new Guid("6bafd882-f8e7-4814-89e2-794003985e82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("b0fccd0e-b813-440d-bc79-e7e76f31de31"), "食品", 1 },
                    { new Guid("ff669fe1-aaf2-432f-9be3-76c7bfba6492"), "消費性電子產品", 2 },
                    { new Guid("6bafd882-f8e7-4814-89e2-794003985e82"), "家電", 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseDetailRecord",
                columns: new[] { "ID", "CurrentPrice", "CustomerID", "ProductID", "PurchaseRecordId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("6e765070-4eea-4588-84c9-1bc6d8030af3"), 30.0, null, new Guid("a42b877b-e470-49a9-83b4-ed98f1eeb62e"), new Guid("e57eb0da-779d-4599-9a91-7e5043acdca8"), 5 },
                    { new Guid("8e7c599d-b546-432c-b71d-26cf9a2d0e69"), 9999.0, null, new Guid("3313eeac-a801-46f2-a9d4-714f3b076485"), new Guid("e57eb0da-779d-4599-9a91-7e5043acdca8"), 1 },
                    { new Guid("51f37c35-a221-4361-bf79-f0ea17460aec"), 999.0, null, new Guid("b9d09d92-4a5c-4648-a8a5-84927c973c1d"), new Guid("e57eb0da-779d-4599-9a91-7e5043acdca8"), 1 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseRecord",
                columns: new[] { "ID", "CreateTime", "CustomerID", "PurchaseDate", "Total" },
                values: new object[] { new Guid("e57eb0da-779d-4599-9a91-7e5043acdca8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e3f32e0-bbf9-4598-9b72-6c3bd8c7d29d"), new DateTime(2020, 12, 16, 15, 12, 30, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "ID", "CreateTime", "Email", "Name", "Phone", "ProductType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("f58dcc70-3fc1-4798-824f-fff8a6222f53"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as542bcmanu@gmail.com", "食品製造商SQA", "0955823845", new Guid("b0fccd0e-b813-440d-bc79-e7e76f31de31"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73897f5d-2285-42ab-95b0-d0c32081558e"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc876manu@gmail.com", "家電製造商SSA", "0989373147", new Guid("6bafd882-f8e7-4814-89e2-794003985e82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f3a8c7e-31fd-4312-ad9f-867bd4a37bcf"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as432bcemanu@gmail.com", "3C製造商ASDW", "0958578943", new Guid("ff669fe1-aaf2-432f-9be3-76c7bfba6492"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("397f7845-8be4-422e-b64c-088b91e7508e"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sadabcmanu@gmail.com", "食品製造商CCC", "0912123845", new Guid("b0fccd0e-b813-440d-bc79-e7e76f31de31"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da2358fa-4415-46fd-a2e9-c626efbd6fad"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "aasdbcmanu@gmail.com", "家電製造商SDDDA", "0989546547", new Guid("6bafd882-f8e7-4814-89e2-794003985e82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("29f39392-1143-4fae-b624-0a7abc67d675"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcmanu@gmail.com", "食品製造商A", "0956123845", new Guid("b0fccd0e-b813-440d-bc79-e7e76f31de31"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6b65edf-fb5e-4198-90c4-918b1f4b74d2"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sabcmanu@gmail.com", "食品製造商C", "0956185845", new Guid("b0fccd0e-b813-440d-bc79-e7e76f31de31"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("933cc821-bbb1-4c68-98eb-e27442b132c6"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbcmanu@gmail.com", "家電製造商A", "0989543147", new Guid("6bafd882-f8e7-4814-89e2-794003985e82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab075326-b646-42e7-9a22-d058119ab05d"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcemanu@gmail.com", "3C製造商A", "0954778943", new Guid("ff669fe1-aaf2-432f-9be3-76c7bfba6492"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a860e835-9e03-4ab9-81b2-22f969fcf645"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ab542cemanu@gmail.com", "3C製造商FSDA", "0954688943", new Guid("ff669fe1-aaf2-432f-9be3-76c7bfba6492"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0f2a74d-e96f-4618-8b31-51fe9ee0bef4"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ssaabcemanu@gmail.com", "3C製造商DDD", "0974778943", new Guid("ff669fe1-aaf2-432f-9be3-76c7bfba6492"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("25128288-1f65-45d5-a592-aff1c612dcf0"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc572manu@gmail.com", "家電製造商QADA", "0986983147", new Guid("6bafd882-f8e7-4814-89e2-794003985e82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
