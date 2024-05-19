using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conembador.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarIdTabelaArquivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Arquivos",
                newName: "Id_Arquivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Arquivo",
                table: "Arquivos",
                newName: "Id");
        }
    }
}
