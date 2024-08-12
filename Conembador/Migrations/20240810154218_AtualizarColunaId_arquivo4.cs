using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conembador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarColunaId_arquivo4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_item",
                table: "item",
                newName: "Id_item");

            migrationBuilder.RenameColumn(
                name: "id_arquivo",
                table: "arquivo",
                newName: "Id_arquivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_item",
                table: "item",
                newName: "id_item");

            migrationBuilder.RenameColumn(
                name: "Id_arquivo",
                table: "arquivo",
                newName: "id_arquivo");
        }
    }
}
