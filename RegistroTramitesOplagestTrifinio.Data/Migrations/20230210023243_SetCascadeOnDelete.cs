using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetCascadeOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tramites_devoluciones_fkey",
                table: "devoluciones");

            migrationBuilder.DropForeignKey(
                name: "tramites_requisitos_tramites_fkey",
                table: "tramites_requisitos");

            migrationBuilder.DropForeignKey(
                name: "tramites_visitas_fkey",
                table: "visitas");

            migrationBuilder.AddForeignKey(
                name: "tramites_devoluciones_fkey",
                table: "devoluciones",
                column: "TramiteId",
                principalTable: "tramites",
                principalColumn: "tramite_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "tramites_requisitos_tramites_fkey",
                table: "tramites_requisitos",
                column: "tramite_id",
                principalTable: "tramites",
                principalColumn: "tramite_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "tramites_visitas_fkey",
                table: "visitas",
                column: "TramiteId",
                principalTable: "tramites",
                principalColumn: "tramite_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tramites_devoluciones_fkey",
                table: "devoluciones");

            migrationBuilder.DropForeignKey(
                name: "tramites_requisitos_tramites_fkey",
                table: "tramites_requisitos");

            migrationBuilder.DropForeignKey(
                name: "tramites_visitas_fkey",
                table: "visitas");

            migrationBuilder.AddForeignKey(
                name: "tramites_devoluciones_fkey",
                table: "devoluciones",
                column: "TramiteId",
                principalTable: "tramites",
                principalColumn: "tramite_id");

            migrationBuilder.AddForeignKey(
                name: "tramites_requisitos_tramites_fkey",
                table: "tramites_requisitos",
                column: "tramite_id",
                principalTable: "tramites",
                principalColumn: "tramite_id");

            migrationBuilder.AddForeignKey(
                name: "tramites_visitas_fkey",
                table: "visitas",
                column: "TramiteId",
                principalTable: "tramites",
                principalColumn: "tramite_id");
        }
    }
}
