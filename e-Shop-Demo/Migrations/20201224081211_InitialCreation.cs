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
                values: new object[] { new Guid("042cf728-d6ba-445d-a2f3-3793fbe56562"), "jackson@example.com", true, new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "/ohjrsvt7bACcAHjb+29hGG7EbXZ1QErLxXHXZMQrPQ=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Activate", "CreateTime", "Password", "Role", "UpdateTime" },
                values: new object[] { new Guid("36990f27-506f-4dc0-9983-8cffe6a4a3f4"), "manager123@example.com", true, new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "UzsxuAjbsHNCXl8C/d2jNWFZ/WvEoOoXMpvXdydnpRQ=", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ImportRecord",
                columns: new[] { "ID", "CreateTime", "ImportPrice", "ProductID", "Quantity", "SupplierID" },
                values: new object[,]
                {
                    { new Guid("66e248b0-6652-47fd-bb97-56afc769a522"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 20.0, new Guid("984d97c1-d71a-44fe-b24e-2415f138bf6f"), 100, new Guid("43baff27-e786-49e1-b11f-c3b22136fcbe") },
                    { new Guid("6ab05479-d8f2-4597-b73a-97d51f384eb1"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 5000.0, new Guid("fb651784-92e8-45db-a26a-c5c8893e5303"), 20, new Guid("dc966460-e48b-478c-9233-cb595b79b040") },
                    { new Guid("02af2c54-215c-4849-86cd-a42a3b9d18a8"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), 600.0, new Guid("d061732e-54dd-4d1f-ad86-30de09ddd6cc"), 30, new Guid("5426bd9a-d51c-47fc-a61d-d81db7c6f3ee") }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreateTime", "Description", "Name", "PictureLink", "Price", "Quantity", "Type", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("984d97c1-d71a-44fe-b24e-2415f138bf6f"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽", "洋芋片", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Potato-Chips.jpg/640px-Potato-Chips.jpg", 30.0, 100, new Guid("9a03f8dd-cc5a-42d4-9d7e-a93caa06bc08"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb651784-92e8-45db-a26a-c5c8893e5303"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "從夜生活到風景照，都能拍得出色； W810 具備可讓您輕鬆拍出清晰精彩相片與 HD 影片的多項功能。6x 光學變焦可讓您拍出細節豐富的特寫相片，派對模式則可讓您輕鬆捕捉精彩夜生活。", "相機", "https://s.yimg.com/zp/images/F84200C57BFF5B8FB763B09688523E28F99D17E3", 9999.0, 20, new Guid("1c967eb5-8827-4b47-a121-410813d0aa30"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d061732e-54dd-4d1f-ad86-30de09ddd6cc"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "風靡全球No.1洋芋片品牌, 香甜馬鈴薯精製成片, 使用剛剛好的鹽提味，簡單清爽", "吹風機", "https://johnlewis.scene7.com/is/image/JohnLewis/237876949", 999.0, 30, new Guid("3d757a26-c456-4e9c-b41d-e106b324cde6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("3d757a26-c456-4e9c-b41d-e106b324cde6"), "Home_Appliances", 3 },
                    { new Guid("9a03f8dd-cc5a-42d4-9d7e-a93caa06bc08"), "Food", 1 },
                    { new Guid("1c967eb5-8827-4b47-a121-410813d0aa30"), "Electronic", 2 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseDetailRecord",
                columns: new[] { "ID", "CurrentPrice", "CustomerID", "ProductID", "PurchaseRecordId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("e2f5b3b4-6924-4f48-bc30-d8ac8f6f2a56"), 30.0, null, new Guid("984d97c1-d71a-44fe-b24e-2415f138bf6f"), new Guid("8aa7a72a-a66b-4c92-a043-6489397b5935"), 5 },
                    { new Guid("0354721e-1ffa-461a-870f-e4259586b81b"), 9999.0, null, new Guid("fb651784-92e8-45db-a26a-c5c8893e5303"), new Guid("8aa7a72a-a66b-4c92-a043-6489397b5935"), 1 },
                    { new Guid("3e24fc1f-7d3a-4827-832e-a77c5f94c296"), 999.0, null, new Guid("d061732e-54dd-4d1f-ad86-30de09ddd6cc"), new Guid("8aa7a72a-a66b-4c92-a043-6489397b5935"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "ID", "CreateTime", "Name", "Phone", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("dc966460-e48b-478c-9233-cb595b79b040"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "3C製造商A", "0954778943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43baff27-e786-49e1-b11f-c3b22136fcbe"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "食品製造商A", "0956123845", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5426bd9a-d51c-47fc-a61d-d81db7c6f3ee"), new DateTime(2020, 12, 16, 13, 12, 30, 0, DateTimeKind.Unspecified), "家電製造商A", "0989543147", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PurchaseRecord",
                columns: new[] { "ID", "CreateTime", "CustomerID", "PurchaseDate", "Total" },
                values: new object[] { new Guid("8aa7a72a-a66b-4c92-a043-6489397b5935"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("042cf728-d6ba-445d-a2f3-3793fbe56562"), new DateTime(2020, 12, 16, 15, 12, 30, 0, DateTimeKind.Unspecified), 0.0 });

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
