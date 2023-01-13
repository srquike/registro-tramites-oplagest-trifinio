using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "correo_electronico_receptor",
                table: "tramites",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "correo_electronico_responsable",
                table: "devoluciones",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "correo_electronico_receptor",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "correo_electronico_responsable",
                table: "devoluciones");
        }
    }
}
