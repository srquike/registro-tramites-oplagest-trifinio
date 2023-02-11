using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOnDeleteSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "direcciones_inmuebles_fkey",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "propietarios_inmuebles_fkey",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "proyectos_inmuebles_fkey",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropForeignKey(
                name: "instructivos_tramites_fkey",
                table: "tramites");

            migrationBuilder.AddForeignKey(
                name: "direcciones_inmuebles_fkey",
                table: "inmuebles",
                column: "direccion_id",
                principalTable: "direcciones",
                principalColumn: "direccion_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "propietarios_inmuebles_fkey",
                table: "inmuebles",
                column: "propietario_id",
                principalTable: "personas",
                principalColumn: "persona_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "proyectos_inmuebles_fkey",
                table: "inmuebles",
                column: "proyecto_id",
                principalTable: "proyectos",
                principalColumn: "proyecto_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites",
                column: "inmueble_id",
                principalTable: "inmuebles",
                principalColumn: "inmueble_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "instructivos_tramites_fkey",
                table: "tramites",
                column: "instructivo_id",
                principalTable: "instructivos",
                principalColumn: "instructivo_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "direcciones_inmuebles_fkey",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "propietarios_inmuebles_fkey",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "proyectos_inmuebles_fkey",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropForeignKey(
                name: "instructivos_tramites_fkey",
                table: "tramites");

            migrationBuilder.AddForeignKey(
                name: "direcciones_inmuebles_fkey",
                table: "inmuebles",
                column: "direccion_id",
                principalTable: "direcciones",
                principalColumn: "direccion_id");

            migrationBuilder.AddForeignKey(
                name: "propietarios_inmuebles_fkey",
                table: "inmuebles",
                column: "propietario_id",
                principalTable: "personas",
                principalColumn: "persona_id");

            migrationBuilder.AddForeignKey(
                name: "proyectos_inmuebles_fkey",
                table: "inmuebles",
                column: "proyecto_id",
                principalTable: "proyectos",
                principalColumn: "proyecto_id");

            migrationBuilder.AddForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites",
                column: "inmueble_id",
                principalTable: "inmuebles",
                principalColumn: "inmueble_id");

            migrationBuilder.AddForeignKey(
                name: "instructivos_tramites_fkey",
                table: "tramites",
                column: "instructivo_id",
                principalTable: "instructivos",
                principalColumn: "instructivo_id");
        }
    }
}
