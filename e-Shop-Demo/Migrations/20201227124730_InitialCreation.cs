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
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
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

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "ID", "Account", "Activate", "BirthDate", "CreateTime", "Password", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("54b50a2b-087f-49e8-9622-6dc8573136fc"), "jackson@example.com", true, new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bea40770-2e93-428d-bdcc-ac0ca3361f8d"), "jdsaon@example.com", true, new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("90498243-3127-4d99-a019-36def2888868"), "jdsao123n@example.com", true, new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("328956e4-ff4c-4388-86ed-9e58e3404db5"), "jdsao123n@example.com", true, new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("737e0942-8cc4-472b-8ab4-4264a0bfc612"), "s4d5623n@example.com", true, new DateTime(1965, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9fcd244d-49dc-4335-b412-a922d4a175d0"), "fsado123n@example.com", true, new DateTime(1952, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("526674f2-94a6-4cb2-bf19-aec6c3ddc320"), "gds45dn@example.com", true, new DateTime(1966, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3d61713-6955-41b2-9f63-e250f2cc8648"), "dsad4923n@example.com", true, new DateTime(2000, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0cad522-d627-4bab-b815-6b3ae35f29ed"), "s46asdn@example.com", true, new DateTime(1989, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Activate", "CreateTime", "Password", "Role", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("d810489c-6278-4d92-adb5-92dc05ead351"), "saad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3afdc236-93d3-4d27-a294-a0ccdd449d12"), "gsaasd55456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa78d0bf-0071-4947-b2d1-ecabc253f441"), "gs49456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0405cb3-43f7-4efd-a073-ad4e047d055d"), "gsad5456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcf1ba19-2dd0-44dc-8149-d1f23a98544e"), "gendsa456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9ce83a55-314a-489f-9048-f73958f2302a"), "manager123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5244883-b05e-4b1d-ac43-dc7dfb1f183c"), "general456@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("23262d1a-561a-4b43-b6e6-e5accb0a705b"), "general123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc664e94-6d43-4d5b-8b2f-8c05406374b9"), "gsas8d46@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc9963e0-3dc8-49fa-abee-57bab30af652"), "admin123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39a5b103-8a7f-40b1-a2cb-f5e64ea96302"), "gene45656@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ImportRecord",
                columns: new[] { "ID", "CreateTime", "ImportPrice", "ProductID", "Quantity", "SupplierID" },
                values: new object[,]
                {
                    { new Guid("480e0f6f-ff3c-4484-bd44-4fe0ab688fbd"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 600.0, new Guid("7a592d83-4f93-46a6-987c-7c657dcfd450"), 30, new Guid("36474647-01a3-4bd1-8456-d138f157472e") },
                    { new Guid("4f5bb230-c054-4ff0-800e-1805ba71431e"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 5000.0, new Guid("10b9285b-8958-4a9a-891c-9c2debdbbf0f"), 20, new Guid("2006913c-16ce-40c4-9a94-3332eaec6675") },
                    { new Guid("e24b823f-4643-44b4-9df8-032ebe5ba70f"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 20.0, new Guid("6a3ba229-4c82-4c8d-95fc-4570ee2160f4"), 100, new Guid("2a9bc729-42b3-4db0-934c-308d5cd275bc") }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreateTime", "Description", "Name", "PictureLink", "Price", "Quantity", "Type", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("6a3ba229-4c82-4c8d-95fc-4570ee2160f4"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽", "洋芋片", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/640px-Potato-Chips.jpg", 30.0, 100, new Guid("0de71ea8-cd80-4d4f-a78d-beb28ab57be5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10b9285b-8958-4a9a-891c-9c2debdbbf0f"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "從夜生活到風景照，都能拍得出色； W810 具備可讓您輕鬆拍出清晰精彩相片與 HD 影片的多項功能。6x 光學變焦可讓您拍出細節豐富的特寫相片，派對模式則可讓您輕鬆捕捉精彩夜生活。", "相機", "https://s.yimg.com/zp/images/F84200C57BFF5B8FB763B09688523E28F99D17E3", 9999.0, 20, new Guid("b9f097e3-3cd3-48ab-9bf8-83f273242cf1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a592d83-4f93-46a6-987c-7c657dcfd450"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "高滲透奈米水離子水分產量提升1800%;礦物負離子出口角度改變效果更集中", "吹風機", "https://johnlewis.scene7.com/is/image/JohnLewis/237876949", 999.0, 30, new Guid("1ae2c11b-538a-4bc6-a42a-809d6f67be0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("0de71ea8-cd80-4d4f-a78d-beb28ab57be5"), "Food", 1 },
                    { new Guid("b9f097e3-3cd3-48ab-9bf8-83f273242cf1"), "Electronic", 2 },
                    { new Guid("1ae2c11b-538a-4bc6-a42a-809d6f67be0e"), "Home_Appliances", 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseDetailRecord",
                columns: new[] { "ID", "CurrentPrice", "CustomerID", "ProductID", "PurchaseRecordId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("65def7d1-87ae-4462-9201-fdeaddbedd53"), 30.0, null, new Guid("6a3ba229-4c82-4c8d-95fc-4570ee2160f4"), new Guid("b3a77d7e-22ea-49d7-829a-4a2d559f8c11"), 5 },
                    { new Guid("640a1a29-2541-4f6e-8f90-abe782e25575"), 9999.0, null, new Guid("10b9285b-8958-4a9a-891c-9c2debdbbf0f"), new Guid("b3a77d7e-22ea-49d7-829a-4a2d559f8c11"), 1 },
                    { new Guid("70d28417-ec5a-4f97-86e5-bd774af7b809"), 999.0, null, new Guid("7a592d83-4f93-46a6-987c-7c657dcfd450"), new Guid("b3a77d7e-22ea-49d7-829a-4a2d559f8c11"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "ID", "CreateTime", "Email", "Name", "Phone", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("b759681a-f56f-4fdc-8efa-06d89e4c17e1"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as542bcmanu@gmail.com", "食品製造商SQA", "0955823845", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0eff8ee-d87b-40b7-a743-b914f2191477"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc876manu@gmail.com", "家電製造商SSA", "0989373147", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("024ec2af-b1b0-44b2-94bf-cba96cbe9cee"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "as432bcemanu@gmail.com", "3C製造商ASDW", "0958578943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f717f57-e425-4f0b-bc69-ae2b6c9b2146"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sadabcmanu@gmail.com", "食品製造商CCC", "0912123845", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bd8bea8f-f830-4d15-94b4-69bb8e604817"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "aasdbcmanu@gmail.com", "家電製造商SDDDA", "0989546547", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a9bc729-42b3-4db0-934c-308d5cd275bc"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcmanu@gmail.com", "食品製造商A", "0956123845", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7a5ed83-abb2-4247-b05b-7b59deeae745"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "sabcmanu@gmail.com", "食品製造商C", "0956185845", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36474647-01a3-4bd1-8456-d138f157472e"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbcmanu@gmail.com", "家電製造商A", "0989543147", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2006913c-16ce-40c4-9a94-3332eaec6675"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "abcemanu@gmail.com", "3C製造商A", "0954778943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a0fa2535-cc5e-47d9-bf7f-feee33bd47b5"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ab542cemanu@gmail.com", "3C製造商FSDA", "0954688943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5753271e-3c6a-4abc-8e78-19649504123c"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "ssaabcemanu@gmail.com", "3C製造商DDD", "0974778943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4282d932-f344-4f23-8b3e-7d060eb501e8"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "dbc572manu@gmail.com", "家電製造商QADA", "0986983147", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PurchaseRecord",
                columns: new[] { "ID", "CreateTime", "CustomerID", "PurchaseDate", "Total" },
                values: new object[] { new Guid("b3a77d7e-22ea-49d7-829a-4a2d559f8c11"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("54b50a2b-087f-49e8-9622-6dc8573136fc"), new DateTime(2020, 12, 16, 15, 12, 30, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailRecord_CustomerID",
                table: "PurchaseDetailRecord",
                column: "CustomerID");

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
