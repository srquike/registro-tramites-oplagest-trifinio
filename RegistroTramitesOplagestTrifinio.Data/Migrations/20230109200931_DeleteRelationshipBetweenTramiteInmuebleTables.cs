using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRelationshipBetweenTramiteInmuebleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropIndex(
                name: "IX_tramites_InmuebleId",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "InmuebleId",
                table: "tramites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InmuebleId",
                table: "tramites",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tramites_InmuebleId",
                table: "tramites",
                column: "InmuebleId");

            migrationBuilder.AddForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites",
                column: "InmuebleId",
                principalTable: "inmuebles",
                principalColumn: "inmueble_id");
        }
    }
}
