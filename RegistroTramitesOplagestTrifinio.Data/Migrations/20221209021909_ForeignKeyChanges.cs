using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "visitas_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropTable(
                name: "tramites_requistos");

            migrationBuilder.DropIndex(
                name: "IX_tramites_visita_id",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "visita_id",
                table: "tramites");

            migrationBuilder.AddColumn<int>(
                name: "TramiteId",
                table: "visitas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Adicional",
                table: "requisitos",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Entregado",
                table: "requisitos",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_visitas_TramiteId",
                table: "visitas",
                column: "TramiteId");

            migrationBuilder.AddForeignKey(
                name: "tramites_visitas_fkey",
                table: "visitas",
                column: "TramiteId",
                principalTable: "tramites",
                principalColumn: "tramite_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tramites_visitas_fkey",
                table: "visitas");

            migrationBuilder.DropIndex(
                name: "IX_visitas_TramiteId",
                table: "visitas");

            migrationBuilder.DropColumn(
                name: "TramiteId",
                table: "visitas");

            migrationBuilder.DropColumn(
                name: "Adicional",
                table: "requisitos");

            migrationBuilder.DropColumn(
                name: "Entregado",
                table: "requisitos");

            migrationBuilder.AddColumn<int>(
                name: "visita_id",
                table: "tramites",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tramites_requistos",
                columns: table => new
                {
                    TramiteRequisitoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequistoId = table.Column<int>(type: "integer", nullable: true),
                    TramiteId = table.Column<int>(type: "integer", nullable: true),
                    adicional = table.Column<bool>(type: "boolean", nullable: true),
                    entregado = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tramites_requisitos_pkey", x => x.TramiteRequisitoId);
                    table.ForeignKey(
                        name: "tramites_requisitos_requistos_fkey",
                        column: x => x.RequistoId,
                        principalTable: "requisitos",
                        principalColumn: "requesito_id");
                    table.ForeignKey(
                        name: "tramites_requisitos_tramites_fkey",
                        column: x => x.TramiteId,
                        principalTable: "tramites",
                        principalColumn: "tramite_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tramites_visita_id",
                table: "tramites",
                column: "visita_id");

            migrationBuilder.CreateIndex(
                name: "IX_tramites_requistos_RequistoId",
                table: "tramites_requistos",
                column: "RequistoId");

            migrationBuilder.CreateIndex(
                name: "IX_tramites_requistos_TramiteId",
                table: "tramites_requistos",
                column: "TramiteId");

            migrationBuilder.AddForeignKey(
                name: "visitas_tramites_fkey",
                table: "tramites",
                column: "visita_id",
                principalTable: "visitas",
                principalColumn: "visita_id");
        }
    }
}
