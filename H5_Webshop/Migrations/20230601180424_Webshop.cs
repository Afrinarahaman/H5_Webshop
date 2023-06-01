using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5_Webshop.Migrations
{
    public partial class Webshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1, "Toy" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "T-Shirt" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Price", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Kids Toys", "microwave.jpg", 299.99m, (short)10, " Kids Microwave" },
                    { 2, 2, "T-Shirt for boys", "BlueTShirt.jpg", 199.99m, (short)10, "Blue T-Shirt" },
                    { 3, 1, "Kids Toys", "motorcycle.jpg", 599.99m, (short)10, " Kids Motorcycle" },
                    { 4, 1, "Soft Baby Sofa for Babies", "BabySofa.jpg", 399.99m, (short)10, " BabySofa" },
                    { 5, 2, "T-Shirt for kids", "RedT-Shirt.jpg", 199.99m, (short)10, "Red T-Shirt" }
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
