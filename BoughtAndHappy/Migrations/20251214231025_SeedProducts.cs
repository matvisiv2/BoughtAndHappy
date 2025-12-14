using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoughtAndHappy.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:product_categories", "electronics,clothing,home_goods,books,toys,groceries,health_and_beauty,sports_and_outdoors,automotive,computers_and_laptops,others");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Electronics", "Smartphone", 699m, 20 },
                    { 2, "Electronics", "Tablet", 399m, 15 },
                    { 3, "Electronics", "Smart TV", 899m, 8 },
                    { 4, "Electronics", "Bluetooth Speaker", 59m, 40 },
                    { 5, "Electronics", "Wireless Headphones", 129m, 30 },
                    { 6, "Electronics", "Power Bank", 39m, 50 },
                    { 7, "Electronics", "Smart Watch", 199m, 25 },
                    { 8, "Clothing", "T-Shirt", 15m, 100 },
                    { 9, "Clothing", "Jeans", 49m, 60 },
                    { 10, "Clothing", "Hoodie", 39m, 40 },
                    { 11, "Clothing", "Jacket", 89m, 25 },
                    { 12, "Clothing", "Sneakers", 79m, 30 },
                    { 13, "Clothing", "Cap", 12m, 70 },
                    { 14, "Clothing", "Socks Pack", 10m, 120 },
                    { 15, "HomeGoods", "Coffee Maker", 99m, 20 },
                    { 16, "HomeGoods", "Vacuum Cleaner", 199m, 10 },
                    { 17, "HomeGoods", "Desk Lamp", 29m, 35 },
                    { 18, "HomeGoods", "Electric Kettle", 49m, 30 },
                    { 19, "HomeGoods", "Toaster", 39m, 25 },
                    { 20, "HomeGoods", "Air Humidifier", 59m, 18 },
                    { 21, "HomeGoods", "Iron", 45m, 22 },
                    { 22, "Books", "C# Programming Guide", 35m, 40 },
                    { 23, "Books", "ASP.NET Core in Action", 45m, 25 },
                    { 24, "Books", "Clean Code", 39m, 30 },
                    { 25, "Books", "Design Patterns", 49m, 20 },
                    { 26, "Books", "Refactoring", 44m, 18 },
                    { 27, "Books", "Domain-Driven Design", 55m, 15 },
                    { 28, "Books", "Algorithms Handbook", 42m, 22 },
                    { 29, "Toys", "Lego Set", 59m, 30 },
                    { 30, "Toys", "Toy Car", 14m, 80 },
                    { 31, "Toys", "Doll", 25m, 40 },
                    { 32, "Toys", "Puzzle 1000 pcs", 19m, 35 },
                    { 33, "Toys", "Board Game", 34m, 28 },
                    { 34, "Toys", "RC Helicopter", 89m, 12 },
                    { 35, "Toys", "Action Figure", 22m, 45 },
                    { 36, "Groceries", "Milk 1L", 2m, 200 },
                    { 37, "Groceries", "Bread", 1.5m, 150 },
                    { 38, "Groceries", "Eggs 10 pcs", 3m, 120 },
                    { 39, "Groceries", "Cheese", 6m, 80 },
                    { 40, "Groceries", "Chicken Breast", 7m, 60 },
                    { 41, "Groceries", "Rice 1kg", 2.5m, 140 },
                    { 42, "Groceries", "Pasta", 1.8m, 160 },
                    { 43, "HealthAndBeauty", "Shampoo", 8m, 70 },
                    { 44, "HealthAndBeauty", "Conditioner", 8m, 65 },
                    { 45, "HealthAndBeauty", "Toothpaste", 3m, 120 },
                    { 46, "HealthAndBeauty", "Body Lotion", 10m, 50 },
                    { 47, "HealthAndBeauty", "Face Cream", 15m, 40 },
                    { 48, "HealthAndBeauty", "Hand Soap", 2.5m, 150 },
                    { 49, "HealthAndBeauty", "Vitamin C", 12m, 55 },
                    { 50, "SportsAndOutdoors", "Football", 25m, 30 },
                    { 51, "SportsAndOutdoors", "Basketball", 27m, 28 },
                    { 52, "SportsAndOutdoors", "Yoga Mat", 20m, 45 },
                    { 53, "SportsAndOutdoors", "Dumbbells Set", 60m, 18 },
                    { 54, "SportsAndOutdoors", "Tennis Racket", 75m, 15 },
                    { 55, "SportsAndOutdoors", "Camping Tent", 120m, 10 },
                    { 56, "SportsAndOutdoors", "Sleeping Bag", 45m, 22 },
                    { 57, "Automotive", "Car Battery", 110m, 12 },
                    { 58, "Automotive", "Engine Oil", 35m, 40 },
                    { 59, "Automotive", "Windshield Wipers", 18m, 50 },
                    { 60, "Automotive", "Car Vacuum Cleaner", 45m, 25 },
                    { 61, "Automotive", "Tire Pressure Gauge", 12m, 60 },
                    { 62, "Automotive", "Jump Starter", 90m, 14 },
                    { 63, "Automotive", "Car Phone Holder", 15m, 70 },
                    { 64, "ComputersAndLaptops", "Laptop", 900m, 10 },
                    { 65, "ComputersAndLaptops", "Gaming PC", 1500m, 6 },
                    { 66, "ComputersAndLaptops", "Mechanical Keyboard", 120m, 20 },
                    { 67, "ComputersAndLaptops", "Wireless Mouse", 40m, 35 },
                    { 68, "ComputersAndLaptops", "27\" Monitor", 300m, 14 },
                    { 69, "ComputersAndLaptops", "USB-C Hub", 45m, 50 },
                    { 70, "ComputersAndLaptops", "External SSD 1TB", 150m, 18 },
                    { 71, "Others", "Gift Card", 50m, 100 },
                    { 72, "Others", "Notebook", 5m, 200 },
                    { 73, "Others", "Pen Set", 7m, 180 },
                    { 74, "Others", "Backpack", 45m, 35 },
                    { 75, "Others", "Travel Mug", 18m, 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
