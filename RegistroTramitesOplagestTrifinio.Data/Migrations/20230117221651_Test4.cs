using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RolId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsuarioId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RolId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UsuarioId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AspNetUserRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RolId",
                table: "AspNetUserRoles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "AspNetUserRoles",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RolId",
                table: "AspNetUserRoles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UsuarioId",
                table: "AspNetUserRoles",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RolId",
                table: "AspNetUserRoles",
                column: "RolId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsuarioId",
                table: "AspNetUserRoles",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
