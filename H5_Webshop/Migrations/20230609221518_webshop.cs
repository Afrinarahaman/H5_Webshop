using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5_Webshop.Migrations
{
    public partial class webshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Stock = table.Column<short>(type: "smallint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Kids" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Men" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Description", "Image", "Price", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 1, "kids dress", "dress1.jpg", 299.99m, (short)10, " Fency dress" },
                    { 2, 2, "T-Shirt for nen", "BlueTShirt.jpg", 199.99m, (short)10, "Blue T-Shirt" },
                    { 3, 1, "Girls skirt", "skirt1.jpg", 159.99m, (short)10, " Skirt" },
                    { 4, 1, "kids jumpersuit", "jumpersuit1.jpg", 279.99m, (short)10, " Jumpersuit" },
                    { 5, 2, "T-Shirt for men", "RedT-Shirt.jpg", 199.99m, (short)10, "Red T-Shirt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
