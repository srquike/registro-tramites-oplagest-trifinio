using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOnDeleteSetNullToTablePersonas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "direcciones_personas_fkey",
                table: "personas");

            migrationBuilder.AddForeignKey(
                name: "direcciones_personas_fkey",
                table: "personas",
                column: "direccion_id",
                principalTable: "direcciones",
                principalColumn: "direccion_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "direcciones_personas_fkey",
                table: "personas");

            migrationBuilder.AddForeignKey(
                name: "direcciones_personas_fkey",
                table: "personas",
                column: "direccion_id",
                principalTable: "direcciones",
                principalColumn: "direccion_id");
        }
    }
}
