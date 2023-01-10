using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshioTramitesInmueblesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "inmueble_id",
                table: "tramites",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tramites_inmueble_id",
                table: "tramites",
                column: "inmueble_id");

            migrationBuilder.AddForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites",
                column: "inmueble_id",
                principalTable: "inmuebles",
                principalColumn: "inmueble_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropIndex(
                name: "IX_tramites_inmueble_id",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "inmueble_id",
                table: "tramites");
        }
    }
}
