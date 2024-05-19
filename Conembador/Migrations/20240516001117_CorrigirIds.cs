using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conembador.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_arquivo_Id_Arquivo",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "Id_Arquivo",
                table: "item",
                newName: "id_arquivo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "item",
                newName: "id_item");

            migrationBuilder.RenameIndex(
                name: "IX_item_Id_Arquivo",
                table: "item",
                newName: "IX_item_id_arquivo");

            migrationBuilder.RenameColumn(
                name: "Id_Arquivo",
                table: "arquivo",
                newName: "id_arquivo");

            migrationBuilder.AddForeignKey(
                name: "FK_item_arquivo_id_arquivo",
                table: "item",
                column: "id_arquivo",
                principalTable: "arquivo",
                principalColumn: "id_arquivo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_arquivo_id_arquivo",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "id_arquivo",
                table: "item",
                newName: "Id_Arquivo");

            migrationBuilder.RenameColumn(
                name: "id_item",
                table: "item",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_item_id_arquivo",
                table: "item",
                newName: "IX_item_Id_Arquivo");

            migrationBuilder.RenameColumn(
                name: "id_arquivo",
                table: "arquivo",
                newName: "Id_Arquivo");

            migrationBuilder.AddForeignKey(
                name: "FK_item_arquivo_Id_Arquivo",
                table: "item",
                column: "Id_Arquivo",
                principalTable: "arquivo",
                principalColumn: "Id_Arquivo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
