using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDataTypeFieldsToTableTramites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "municipio",
                table: "tramites",
                newName: "Municipio");

            migrationBuilder.RenameColumn(
                name: "departamento",
                table: "tramites",
                newName: "Departamento");

            migrationBuilder.AlterColumn<string>(
                name: "Municipio",
                table: "tramites",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "tramites",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "departamento_id",
                table: "tramites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "municipio_id",
                table: "tramites",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "departamento_id",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "municipio_id",
                table: "tramites");

            migrationBuilder.RenameColumn(
                name: "Municipio",
                table: "tramites",
                newName: "municipio");

            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "tramites",
                newName: "departamento");

            migrationBuilder.AlterColumn<string>(
                name: "municipio",
                table: "tramites",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "departamento",
                table: "tramites",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
