using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterar_nome_produto_para_produtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCoresProdutos_Produto_prodtuoId",
                table: "CarrinhoCoresProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Compras_CompraId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuarios_UsuarioId",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_UsuarioId",
                table: "Produtos",
                newName: "IX_Produtos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_CompraId",
                table: "Produtos",
                newName: "IX_Produtos_CompraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCoresProdutos_Produtos_prodtuoId",
                table: "CarrinhoCoresProdutos",
                column: "prodtuoId",
                principalTable: "Produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Compras_CompraId",
                table: "Produtos",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuarios_UsuarioId",
                table: "Produtos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCoresProdutos_Produtos_prodtuoId",
                table: "CarrinhoCoresProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Compras_CompraId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuarios_UsuarioId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_UsuarioId",
                table: "Produto",
                newName: "IX_Produto_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CompraId",
                table: "Produto",
                newName: "IX_Produto_CompraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCoresProdutos_Produto_prodtuoId",
                table: "CarrinhoCoresProdutos",
                column: "prodtuoId",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Compras_CompraId",
                table: "Produto",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuarios_UsuarioId",
                table: "Produto",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
