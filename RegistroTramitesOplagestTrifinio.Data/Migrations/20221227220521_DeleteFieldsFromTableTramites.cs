using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFieldsFromTableTramites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "tramites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "tramites",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "tramites",
                type: "text",
                nullable: true);
        }
    }
}
