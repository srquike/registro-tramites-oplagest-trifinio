using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDireccionesRelationshipFromInmueblesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "direcciones_inmuebles_fkey",
                table: "inmuebles");

            migrationBuilder.DropIndex(
                name: "IX_inmuebles_direccion_id",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "direccion_id",
                table: "inmuebles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "direccion_id",
                table: "inmuebles",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_direccion_id",
                table: "inmuebles",
                column: "direccion_id");

            migrationBuilder.AddForeignKey(
                name: "direcciones_inmuebles_fkey",
                table: "inmuebles",
                column: "direccion_id",
                principalTable: "direcciones",
                principalColumn: "direccion_id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
