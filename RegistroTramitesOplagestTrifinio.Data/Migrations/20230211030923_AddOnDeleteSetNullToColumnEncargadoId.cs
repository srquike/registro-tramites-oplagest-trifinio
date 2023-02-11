using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOnDeleteSetNullToColumnEncargadoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "personas_proyectos_fkey",
                table: "proyectos");

            migrationBuilder.AddForeignKey(
                name: "personas_proyectos_fkey",
                table: "proyectos",
                column: "encargado_id",
                principalTable: "personas",
                principalColumn: "persona_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "personas_proyectos_fkey",
                table: "proyectos");

            migrationBuilder.AddForeignKey(
                name: "personas_proyectos_fkey",
                table: "proyectos",
                column: "encargado_id",
                principalTable: "personas",
                principalColumn: "persona_id");
        }
    }
}
