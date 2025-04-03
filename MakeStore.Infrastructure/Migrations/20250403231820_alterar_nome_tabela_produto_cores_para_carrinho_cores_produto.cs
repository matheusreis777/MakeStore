using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterar_nome_tabela_produto_cores_para_carrinho_cores_produto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoresProdutos_Carrinho_produtoId",
                table: "CoresProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoresProdutos",
                table: "CoresProdutos");

            migrationBuilder.RenameTable(
                name: "CoresProdutos",
                newName: "CarrinhoCoresProdutos");

            migrationBuilder.RenameColumn(
                name: "produtoId",
                table: "CarrinhoCoresProdutos",
                newName: "carrinhoId");

            migrationBuilder.RenameIndex(
                name: "IX_CoresProdutos_produtoId",
                table: "CarrinhoCoresProdutos",
                newName: "IX_CarrinhoCoresProdutos_carrinhoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoCoresProdutos",
                table: "CarrinhoCoresProdutos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCoresProdutos_Carrinho_carrinhoId",
                table: "CarrinhoCoresProdutos",
                column: "carrinhoId",
                principalTable: "Carrinho",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCoresProdutos_Carrinho_carrinhoId",
                table: "CarrinhoCoresProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoCoresProdutos",
                table: "CarrinhoCoresProdutos");

            migrationBuilder.RenameTable(
                name: "CarrinhoCoresProdutos",
                newName: "CoresProdutos");

            migrationBuilder.RenameColumn(
                name: "carrinhoId",
                table: "CoresProdutos",
                newName: "produtoId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCoresProdutos_carrinhoId",
                table: "CoresProdutos",
                newName: "IX_CoresProdutos_produtoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoresProdutos",
                table: "CoresProdutos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoresProdutos_Carrinho_produtoId",
                table: "CoresProdutos",
                column: "produtoId",
                principalTable: "Carrinho",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
