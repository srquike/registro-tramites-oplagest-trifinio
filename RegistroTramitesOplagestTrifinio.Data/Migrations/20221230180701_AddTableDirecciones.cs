using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableDirecciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "departamento_id",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "direccion",
                table: "tramites");

            migrationBuilder.RenameColumn(
                name: "municipio_id",
                table: "tramites",
                newName: "direccion_id");

            migrationBuilder.CreateTable(
                name: "direcciones",
                columns: table => new
                {
                    departamentoid = table.Column<int>(name: "departamento_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    direccion = table.Column<string>(type: "character varying", nullable: true),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("direcciones_pkey", x => x.departamentoid);
                    table.ForeignKey(
                        name: "departamentos_direcciones_fkey",
                        column: x => x.DepartamentoId,
                        principalTable: "departamentos",
                        principalColumn: "DepartamentoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tramites_direccion_id",
                table: "tramites",
                column: "direccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_direcciones_DepartamentoId",
                table: "direcciones",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "direcciones_tramites_fkey",
                table: "tramites",
                column: "direccion_id",
                principalTable: "direcciones",
                principalColumn: "departamento_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "direcciones_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropTable(
                name: "direcciones");

            migrationBuilder.DropIndex(
                name: "IX_tramites_direccion_id",
                table: "tramites");

            migrationBuilder.RenameColumn(
                name: "direccion_id",
                table: "tramites",
                newName: "municipio_id");

            migrationBuilder.AddColumn<int>(
                name: "departamento_id",
                table: "tramites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "tramites",
                type: "character varying",
                nullable: true);
        }
    }
}
