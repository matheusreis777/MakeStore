using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class altera_colunas_e_criar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Compras");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "20");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Compras",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
