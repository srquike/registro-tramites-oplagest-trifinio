using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDireccionesRelationshipFromPersonasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "direcciones_personas_fkey",
                table: "personas");

            migrationBuilder.DropIndex(
                name: "IX_personas_direccion_id",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "direccion_id",
                table: "personas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "direccion_id",
                table: "personas",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_personas_direccion_id",
                table: "personas",
                column: "direccion_id");

            migrationBuilder.AddForeignKey(
                name: "direcciones_personas_fkey",
                table: "personas",
                column: "direccion_id",
                principalTable: "direcciones",
                principalColumn: "direccion_id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
