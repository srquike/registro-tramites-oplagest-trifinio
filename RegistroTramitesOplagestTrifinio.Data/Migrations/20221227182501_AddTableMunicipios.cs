using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableMunicipios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "municipios",
                columns: table => new
                {
                    municipioid = table.Column<int>(name: "municipio_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying", nullable: true),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("municipios_pkey", x => x.municipioid);
                    table.ForeignKey(
                        name: "departamentos_municipios_fkey",
                        column: x => x.DepartamentoId,
                        principalTable: "departamentos",
                        principalColumn: "DepartamentoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_municipios_DepartamentoId",
                table: "municipios",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "municipios");
        }
    }
}
