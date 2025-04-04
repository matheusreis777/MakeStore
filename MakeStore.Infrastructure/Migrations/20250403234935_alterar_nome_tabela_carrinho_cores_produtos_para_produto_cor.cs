using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterar_nome_tabela_carrinho_cores_produtos_para_produto_cor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCoresProdutos_Produtos_prodtuoId",
                table: "CarrinhoCoresProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoCoresProdutos",
                table: "CarrinhoCoresProdutos");

            migrationBuilder.RenameTable(
                name: "CarrinhoCoresProdutos",
                newName: "ProdutoCor");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCoresProdutos_prodtuoId",
                table: "ProdutoCor",
                newName: "IX_ProdutoCor_prodtuoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoCor",
                table: "ProdutoCor",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoCor_Produtos_prodtuoId",
                table: "ProdutoCor",
                column: "prodtuoId",
                principalTable: "Produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoCor_Produtos_prodtuoId",
                table: "ProdutoCor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoCor",
                table: "ProdutoCor");

            migrationBuilder.RenameTable(
                name: "ProdutoCor",
                newName: "CarrinhoCoresProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoCor_prodtuoId",
                table: "CarrinhoCoresProdutos",
                newName: "IX_CarrinhoCoresProdutos_prodtuoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoCoresProdutos",
                table: "CarrinhoCoresProdutos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCoresProdutos_Produtos_prodtuoId",
                table: "CarrinhoCoresProdutos",
                column: "prodtuoId",
                principalTable: "Produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
