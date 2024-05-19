using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conembador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarNomeTabelasArquivoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Arquivos_Id_Arquivo",
                table: "Itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Itens",
                table: "Itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arquivos",
                table: "Arquivos");

            migrationBuilder.RenameTable(
                name: "Itens",
                newName: "item");

            migrationBuilder.RenameTable(
                name: "Arquivos",
                newName: "arquivo");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_Id_Arquivo",
                table: "item",
                newName: "IX_item_Id_Arquivo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item",
                table: "item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_arquivo",
                table: "arquivo",
                column: "Id_Arquivo");

            migrationBuilder.AddForeignKey(
                name: "FK_item_arquivo_Id_Arquivo",
                table: "item",
                column: "Id_Arquivo",
                principalTable: "arquivo",
                principalColumn: "Id_Arquivo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_arquivo_Id_Arquivo",
                table: "item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_item",
                table: "item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_arquivo",
                table: "arquivo");

            migrationBuilder.RenameTable(
                name: "item",
                newName: "Itens");

            migrationBuilder.RenameTable(
                name: "arquivo",
                newName: "Arquivos");

            migrationBuilder.RenameIndex(
                name: "IX_item_Id_Arquivo",
                table: "Itens",
                newName: "IX_Itens_Id_Arquivo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Itens",
                table: "Itens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arquivos",
                table: "Arquivos",
                column: "Id_Arquivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Arquivos_Id_Arquivo",
                table: "Itens",
                column: "Id_Arquivo",
                principalTable: "Arquivos",
                principalColumn: "Id_Arquivo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
