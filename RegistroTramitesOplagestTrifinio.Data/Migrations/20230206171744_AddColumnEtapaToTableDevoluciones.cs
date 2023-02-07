using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnEtapaToTableDevoluciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "etapa",
                table: "devoluciones",
                type: "character varying",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "etapa",
                table: "devoluciones");
        }
    }
}
