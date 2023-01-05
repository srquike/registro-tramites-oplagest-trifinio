using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "direcciones_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "propietario",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "tipo_construccion",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "tipo_proyecto",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "tipo_tramite",
                table: "tramites");

            migrationBuilder.RenameColumn(
                name: "direccion_id",
                table: "tramites",
                newName: "ProyectoId");

            migrationBuilder.RenameIndex(
                name: "IX_tramites_direccion_id",
                table: "tramites",
                newName: "IX_tramites_ProyectoId");

            migrationBuilder.AddColumn<int>(
                name: "DireccionModelDireccionId",
                table: "tramites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InmuebleId",
                table: "tramites",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    personaid = table.Column<int>(name: "persona_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    correoelectronico = table.Column<string>(name: "correo_electronico", type: "text", nullable: true),
                    telefono = table.Column<string>(type: "text", nullable: true),
                    direccionid = table.Column<int>(name: "direccion_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("personas_pkey", x => x.personaid);
                    table.ForeignKey(
                        name: "direcciones_personas_fkey",
                        column: x => x.direccionid,
                        principalTable: "direcciones",
                        principalColumn: "direccion_id");
                });

            migrationBuilder.CreateTable(
                name: "inmuebles",
                columns: table => new
                {
                    inmuebleid = table.Column<int>(name: "inmueble_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    area = table.Column<double>(type: "double precision", nullable: true),
                    propietarioid = table.Column<int>(name: "propietario_id", type: "integer", nullable: true),
                    direccionid = table.Column<int>(name: "direccion_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inmuebles_pkey", x => x.inmuebleid);
                    table.ForeignKey(
                        name: "direcciones_inmuebles_fkey",
                        column: x => x.direccionid,
                        principalTable: "direcciones",
                        principalColumn: "direccion_id");
                    table.ForeignKey(
                        name: "propietarios_inmuebles_fkey",
                        column: x => x.propietarioid,
                        principalTable: "personas",
                        principalColumn: "persona_id");
                });

            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    proyectoid = table.Column<int>(name: "proyecto_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    encargadoid = table.Column<int>(name: "encargado_id", type: "integer", nullable: true),
                    DireccionModelDireccionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("proyectos_pkey", x => x.proyectoid);
                    table.ForeignKey(
                        name: "FK_proyectos_direcciones_DireccionModelDireccionId",
                        column: x => x.DireccionModelDireccionId,
                        principalTable: "direcciones",
                        principalColumn: "direccion_id");
                    table.ForeignKey(
                        name: "personas_proyectos_fkey",
                        column: x => x.encargadoid,
                        principalTable: "personas",
                        principalColumn: "persona_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tramites_DireccionModelDireccionId",
                table: "tramites",
                column: "DireccionModelDireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_tramites_InmuebleId",
                table: "tramites",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_direccion_id",
                table: "inmuebles",
                column: "direccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_propietario_id",
                table: "inmuebles",
                column: "propietario_id");

            migrationBuilder.CreateIndex(
                name: "IX_personas_direccion_id",
                table: "personas",
                column: "direccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_DireccionModelDireccionId",
                table: "proyectos",
                column: "DireccionModelDireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_encargado_id",
                table: "proyectos",
                column: "encargado_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tramites_direcciones_DireccionModelDireccionId",
                table: "tramites",
                column: "DireccionModelDireccionId",
                principalTable: "direcciones",
                principalColumn: "direccion_id");

            migrationBuilder.AddForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites",
                column: "InmuebleId",
                principalTable: "inmuebles",
                principalColumn: "inmueble_id");

            migrationBuilder.AddForeignKey(
                name: "proyectos_tramites_fkey",
                table: "tramites",
                column: "ProyectoId",
                principalTable: "proyectos",
                principalColumn: "proyecto_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tramites_direcciones_DireccionModelDireccionId",
                table: "tramites");

            migrationBuilder.DropForeignKey(
                name: "inmuebles_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropForeignKey(
                name: "proyectos_tramites_fkey",
                table: "tramites");

            migrationBuilder.DropTable(
                name: "inmuebles");

            migrationBuilder.DropTable(
                name: "proyectos");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropIndex(
                name: "IX_tramites_DireccionModelDireccionId",
                table: "tramites");

            migrationBuilder.DropIndex(
                name: "IX_tramites_InmuebleId",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "DireccionModelDireccionId",
                table: "tramites");

            migrationBuilder.DropColumn(
                name: "InmuebleId",
                table: "tramites");

            migrationBuilder.RenameColumn(
                name: "ProyectoId",
                table: "tramites",
                newName: "direccion_id");

            migrationBuilder.RenameIndex(
                name: "IX_tramites_ProyectoId",
                table: "tramites",
                newName: "IX_tramites_direccion_id");

            migrationBuilder.AddColumn<string>(
                name: "propietario",
                table: "tramites",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefono",
                table: "tramites",
                type: "character(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo_construccion",
                table: "tramites",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo_proyecto",
                table: "tramites",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo_tramite",
                table: "tramites",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "direcciones_tramites_fkey",
                table: "tramites",
                column: "direccion_id",
                principalTable: "direcciones",
                principalColumn: "direccion_id");
        }
    }
}
