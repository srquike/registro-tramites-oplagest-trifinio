using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingRequisitoFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequistoId",
                table: "tramites_requisitos",
                newName: "RequisitoId");

            migrationBuilder.RenameIndex(
                name: "IX_tramites_requisitos_RequistoId",
                table: "tramites_requisitos",
                newName: "IX_tramites_requisitos_RequisitoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequisitoId",
                table: "tramites_requisitos",
                newName: "RequistoId");

            migrationBuilder.RenameIndex(
                name: "IX_tramites_requisitos_RequisitoId",
                table: "tramites_requisitos",
                newName: "IX_tramites_requisitos_RequistoId");
        }
    }
}
