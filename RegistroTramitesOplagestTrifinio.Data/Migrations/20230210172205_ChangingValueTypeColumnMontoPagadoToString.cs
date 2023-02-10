using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingValueTypeColumnMontoPagadoToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "monto_pagado",
                table: "tramites",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "monto_pagado",
                table: "tramites",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
