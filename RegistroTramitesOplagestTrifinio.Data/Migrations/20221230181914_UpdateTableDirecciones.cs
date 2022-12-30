using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableDirecciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "departamentos_direcciones_fkey",
                table: "direcciones");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "municipios",
                newName: "departamento_id");

            migrationBuilder.RenameIndex(
                name: "IX_municipios_DepartamentoId",
                table: "municipios",
                newName: "IX_municipios_departamento_id");

            migrationBuilder.RenameColumn(
                name: "departamento_id",
                table: "direcciones",
                newName: "direccion_id");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "direcciones",
                newName: "municipio_id");

            migrationBuilder.RenameIndex(
                name: "IX_direcciones_DepartamentoId",
                table: "direcciones",
                newName: "IX_direcciones_municipio_id");

            migrationBuilder.AddForeignKey(
                name: "municipios_direcciones_fkey",
                table: "direcciones",
                column: "municipio_id",
                principalTable: "municipios",
                principalColumn: "municipio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "municipios_direcciones_fkey",
                table: "direcciones");

            migrationBuilder.RenameColumn(
                name: "departamento_id",
                table: "municipios",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_municipios_departamento_id",
                table: "municipios",
                newName: "IX_municipios_DepartamentoId");

            migrationBuilder.RenameColumn(
                name: "direccion_id",
                table: "direcciones",
                newName: "departamento_id");

            migrationBuilder.RenameColumn(
                name: "municipio_id",
                table: "direcciones",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_direcciones_municipio_id",
                table: "direcciones",
                newName: "IX_direcciones_DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "departamentos_direcciones_fkey",
                table: "direcciones",
                column: "DepartamentoId",
                principalTable: "departamentos",
                principalColumn: "DepartamentoId");
        }
    }
}
