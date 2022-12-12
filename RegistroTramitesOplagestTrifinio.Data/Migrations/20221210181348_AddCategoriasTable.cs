using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adicional",
                table: "requisitos");

            migrationBuilder.DropColumn(
                name: "Entregado",
                table: "requisitos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "requisitos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categorias_pkey", x => x.CategoriaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requisitos_CategoriaId",
                table: "requisitos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "categorias_requisitos_fkey",
                table: "requisitos",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "categorias_requisitos_fkey",
                table: "requisitos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropIndex(
                name: "IX_requisitos_CategoriaId",
                table: "requisitos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "requisitos");

            migrationBuilder.AddColumn<bool>(
                name: "Adicional",
                table: "requisitos",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Entregado",
                table: "requisitos",
                type: "boolean",
                nullable: true);
        }
    }
}
