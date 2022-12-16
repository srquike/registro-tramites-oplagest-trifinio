using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddComentariosDevolucionColumnToTramitesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComentariosDevolucion",
                table: "tramites",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentariosDevolucion",
                table: "tramites");
        }
    }
}
