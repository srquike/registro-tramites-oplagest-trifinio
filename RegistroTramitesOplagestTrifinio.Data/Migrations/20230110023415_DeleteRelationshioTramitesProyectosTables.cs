using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRelationshioTramitesProyectosTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "proyectos_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropIndex(
                name: "IX_tramites_ProyectoId",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "ProyectoId",
                table: "tramites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProyectoId",
                table: "tramites",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tramites_ProyectoId",
                table: "tramites",
                column: "ProyectoId");

            migrationBuilder.AddForeignKey(
                name: "proyectos_tramites_fkey",
                table: "tramites",
                column: "ProyectoId",
                principalTable: "proyectos",
                principalColumn: "proyecto_id");
        }
    }
}
