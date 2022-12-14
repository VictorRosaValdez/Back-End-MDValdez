using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDValdez.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Account_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Account_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartProduct", x => new { x.ProductId, x.ShoppingCartId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProduct_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CustomerName", "Discriminator", "Email", "Password", "adress" },
                values: new object[,]
                {
                    { 1, "jan", "Customer", "jantest@hotmail.com", "admin123", "Landlaan 1" },
                    { 2, "peter", "Customer", "petertest@hotmail.com", "welcome", "Kade 3" },
                    { 3, "jost", "Customer", "josttest@hotmail.com", "welcome2", "Sonseweg 15" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Category", "Description", "Name", "OrderCode", "Stock", "picture" },
                values: new object[,]
                {
                    { 1, "coat", "De beste jas ooit", "Mooie Jas", "beste154", 0, null },
                    { 2, "jewelry", "Gouden sieraden", "Mooie sieraden", "beste11", 0, null },
                    { 3, "shoes", "De beste schoenen ooit gemaakt", "Beste schoenen ooit", "beste1122", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "OrderAmount", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, 250.5, new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4692) },
                    { 2, 2, 100.0, new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4696) },
                    { 3, 3, 300.0, new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4698) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "ShoppingCartId", "CustomerId", "Date", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4615), 100.0 },
                    { 2, 1, new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4665), 200.0 },
                    { 3, 1, new DateTime(2022, 12, 9, 16, 36, 21, 766, DateTimeKind.Local).AddTicks(4668), 300.0 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartProduct",
                columns: new[] { "ProductId", "ShoppingCartId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "ShoppingCartProduct",
                columns: new[] { "ProductId", "ShoppingCartId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "ShoppingCartProduct",
                columns: new[] { "ProductId", "ShoppingCartId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProduct_ShoppingCartId",
                table: "ShoppingCartProduct",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ShoppingCartProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
