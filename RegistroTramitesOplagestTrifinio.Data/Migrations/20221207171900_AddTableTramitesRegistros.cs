using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTramitesRegistros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adicional",
                table: "requisitos");

            migrationBuilder.CreateTable(
                name: "tramites_requistos",
                columns: table => new
                {
                    TramiteRequisitoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entregado = table.Column<bool>(type: "boolean", nullable: true),
                    adicional = table.Column<bool>(type: "boolean", nullable: true),
                    TramiteId = table.Column<int>(type: "integer", nullable: true),
                    RequistoId = table.Column<int>(type: "integer", nullable: true)
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
                name: "IX_tramites_requistos_RequistoId",
                table: "tramites_requistos",
                column: "RequistoId");

            migrationBuilder.CreateIndex(
                name: "IX_tramites_requistos_TramiteId",
                table: "tramites_requistos",
                column: "TramiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tramites_requistos");

            migrationBuilder.AddColumn<bool>(
                name: "adicional",
                table: "requisitos",
                type: "boolean",
                nullable: true);
        }
    }
}
