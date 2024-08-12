using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conembador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarColunaId_arquivo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_arquivo_id_arquivo",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "id_arquivo",
                table: "item",
                newName: "Id_arquivo");

            migrationBuilder.RenameIndex(
                name: "IX_item_id_arquivo",
                table: "item",
                newName: "IX_item_Id_arquivo");

            migrationBuilder.AddForeignKey(
                name: "FK_item_arquivo_Id_arquivo",
                table: "item",
                column: "Id_arquivo",
                principalTable: "arquivo",
                principalColumn: "id_arquivo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_arquivo_Id_arquivo",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "Id_arquivo",
                table: "item",
                newName: "id_arquivo");

            migrationBuilder.RenameIndex(
                name: "IX_item_Id_arquivo",
                table: "item",
                newName: "IX_item_id_arquivo");

            migrationBuilder.AddForeignKey(
                name: "FK_item_arquivo_id_arquivo",
                table: "item",
                column: "id_arquivo",
                principalTable: "arquivo",
                principalColumn: "id_arquivo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
