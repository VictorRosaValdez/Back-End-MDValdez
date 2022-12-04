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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
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
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartId");
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CustomerName", "Discriminator", "Email", "adress" },
                values: new object[,]
                {
                    { 1, "Jan", "Customer", "jantest@hotmail.com", "Landlaan 1" },
                    { 2, "Peter", "Customer", "petertest@hotmail.com", "Kade 3" },
                    { 3, "Jost", "Customer", "josttest@hotmail.com", "Sonseweg 15" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Description", "Name", "OrderCode", "ShoppingCartId", "Stock", "picture" },
                values: new object[,]
                {
                    { 1, "De beste schoenen ooit", "Mooie schoenen", "beste154", null, 0, null },
                    { 2, "Een leuke zomerse T-Shirt", "T-Shirt", "beste11", null, 0, null },
                    { 3, "Geweldige broek", "Broek", "beste1122", null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "OrderAmount", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, 250.5, new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2417) },
                    { 2, 2, 100.0, new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2423) },
                    { 3, 3, 300.0, new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2426) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "ShoppingCartId", "CustomerId", "Date", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2317), 100.0 },
                    { 2, 1, new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2358), 200.0 },
                    { 3, 1, new DateTime(2022, 12, 4, 18, 59, 57, 702, DateTimeKind.Local).AddTicks(2360), 300.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShoppingCartId",
                table: "Product",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
