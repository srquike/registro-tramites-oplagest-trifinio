using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipProyectosInmueblesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "proyecto_id",
                table: "inmuebles",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_proyecto_id",
                table: "inmuebles",
                column: "proyecto_id");

            migrationBuilder.AddForeignKey(
                name: "proyectos_inmuebles_fkey",
                table: "inmuebles",
                column: "proyecto_id",
                principalTable: "proyectos",
                principalColumn: "proyecto_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "proyectos_inmuebles_fkey",
                table: "inmuebles");

            migrationBuilder.DropIndex(
                name: "IX_inmuebles_proyecto_id",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "proyecto_id",
                table: "inmuebles");
        }
    }
}
