using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ajustes_de_tabelas_criacao_compras_alteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Usuarios_UsuarioId",
                table: "Carrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCoresProdutos_Carrinho_carrinhoId",
                table: "CarrinhoCoresProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho");

            migrationBuilder.RenameTable(
                name: "Carrinho",
                newName: "Produto");

            migrationBuilder.RenameColumn(
                name: "carrinhoId",
                table: "CarrinhoCoresProdutos",
                newName: "prodtuoId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCoresProdutos_carrinhoId",
                table: "CarrinhoCoresProdutos",
                newName: "IX_CarrinhoCoresProdutos_prodtuoId");

            migrationBuilder.RenameIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Produto",
                newName: "IX_Produto_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "quantidade",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CompraId",
                table: "Produto",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras",
                column: "UsuarioId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_CompraId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Carrinho");

            migrationBuilder.RenameColumn(
                name: "prodtuoId",
                table: "CarrinhoCoresProdutos",
                newName: "carrinhoId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCoresProdutos_prodtuoId",
                table: "CarrinhoCoresProdutos",
                newName: "IX_CarrinhoCoresProdutos_carrinhoId");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_UsuarioId",
                table: "Carrinho",
                newName: "IX_Carrinho_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Usuarios_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCoresProdutos_Carrinho_carrinhoId",
                table: "CarrinhoCoresProdutos",
                column: "carrinhoId",
                principalTable: "Carrinho",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
