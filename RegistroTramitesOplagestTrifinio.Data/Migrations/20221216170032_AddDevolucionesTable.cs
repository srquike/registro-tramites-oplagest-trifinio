using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDevolucionesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentariosDevolucion",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "motivo_devolucion",
                table: "tramites");

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaFinalizacion",
                table: "visitas",
                type: "date",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "devoluciones",
                columns: table => new
                {
                    DevolucionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    motivo = table.Column<string>(type: "character varying", nullable: true),
                    comentarios = table.Column<string>(type: "character varying", nullable: true),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    TramiteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("devoluciones_pkey", x => x.DevolucionId);
                    table.ForeignKey(
                        name: "tramites_devoluciones_fkey",
                        column: x => x.TramiteId,
                        principalTable: "tramites",
                        principalColumn: "tramite_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_devoluciones_TramiteId",
                table: "devoluciones",
                column: "TramiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devoluciones");

            migrationBuilder.DropColumn(
                name: "FechaFinalizacion",
                table: "visitas");

            migrationBuilder.AddColumn<string>(
                name: "ComentariosDevolucion",
                table: "tramites",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motivo_devolucion",
                table: "tramites",
                type: "character varying",
                nullable: true);
        }
    }
}
