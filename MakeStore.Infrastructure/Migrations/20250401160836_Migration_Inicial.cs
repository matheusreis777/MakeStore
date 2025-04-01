using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    price_sign = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    image_link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    product_link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    website_link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    rating = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    product_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    product_api_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    api_featured_image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CoresProdutos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produtoId = table.Column<int>(type: "int", nullable: false),
                    hex_value = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    colour_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoresProdutos", x => x.id);
                    table.ForeignKey(
                        name: "FK_CoresProdutos_Produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoresProdutos_produtoId",
                table: "CoresProdutos",
                column: "produtoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoresProdutos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
