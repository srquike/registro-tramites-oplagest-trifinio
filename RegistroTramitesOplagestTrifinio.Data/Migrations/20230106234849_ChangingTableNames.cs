using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TramiteId",
                table: "tramites_requisitos",
                newName: "tramite_id");

            migrationBuilder.RenameColumn(
                name: "RequisitoId",
                table: "tramites_requisitos",
                newName: "requisito_id");

            migrationBuilder.RenameColumn(
                name: "TramiteRequisitoId",
                table: "tramites_requisitos",
                newName: "tramite_requisito_id");

            migrationBuilder.RenameIndex(
                name: "IX_tramites_requisitos_TramiteId",
                table: "tramites_requisitos",
                newName: "IX_tramites_requisitos_tramite_id");

            migrationBuilder.RenameIndex(
                name: "IX_tramites_requisitos_RequisitoId",
                table: "tramites_requisitos",
                newName: "IX_tramites_requisitos_requisito_id");

            migrationBuilder.RenameColumn(
                name: "requesito_id",
                table: "requisitos",
                newName: "requisito_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tramite_id",
                table: "tramites_requisitos",
                newName: "TramiteId");

            migrationBuilder.RenameColumn(
                name: "requisito_id",
                table: "tramites_requisitos",
                newName: "RequisitoId");

            migrationBuilder.RenameColumn(
                name: "tramite_requisito_id",
                table: "tramites_requisitos",
                newName: "TramiteRequisitoId");

            migrationBuilder.RenameIndex(
                name: "IX_tramites_requisitos_tramite_id",
                table: "tramites_requisitos",
                newName: "IX_tramites_requisitos_TramiteId");

            migrationBuilder.RenameIndex(
                name: "IX_tramites_requisitos_requisito_id",
                table: "tramites_requisitos",
                newName: "IX_tramites_requisitos_RequisitoId");

            migrationBuilder.RenameColumn(
                name: "requisito_id",
                table: "requisitos",
                newName: "requesito_id");
        }
    }
}
