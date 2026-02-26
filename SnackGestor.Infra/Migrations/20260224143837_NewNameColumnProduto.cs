using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackGestor.Infra.Migrations
{
    /// <inheritdoc />
    public partial class NewNameColumnProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Produtos",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_Name",
                table: "Produtos",
                newName: "IX_Produtos_Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Produtos",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_Nome",
                table: "Produtos",
                newName: "IX_Produtos_Name");
        }
    }
}
