﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RegistroTramitesOplagestTrifinio.Data;

#nullable disable

namespace RegistroTramitesOplagestTrifinio.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230113213126_AddFields")]
    partial class AddFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.ActividadModel", b =>
                {
                    b.Property<int>("ActividadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("actividad_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("ActividadId"));

                    b.Property<DateOnly>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("fecha")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<TimeOnly?>("Hora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("time without time zone")
                        .HasColumnName("hora")
                        .HasDefaultValueSql("CURRENT_TIME");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("character varying")
                        .HasColumnName("usuario");

                    b.Property<string>("Resumen")
                        .HasColumnType("character varying")
                        .HasColumnName("resumen");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("text");

                    b.HasKey("ActividadId")
                        .HasName("actividades_pkey");

                    b.HasIndex("UsuarioId");

                    b.ToTable("actividades", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.CategoriaModel", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("Nombre")
                        .HasColumnType("character varying")
                        .HasColumnName("nombre");

                    b.HasKey("CategoriaId")
                        .HasName("categorias_pkey");

                    b.ToTable("categorias", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.DepartamentoModel", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartamentoId"));

                    b.Property<string>("Iso")
                        .HasColumnType("character varying")
                        .HasColumnName("iso");

                    b.Property<string>("Nombre")
                        .HasColumnType("character varying")
                        .HasColumnName("nombre");

                    b.HasKey("DepartamentoId")
                        .HasName("departamentos_pkey");

                    b.ToTable("departamentos", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.DevolucionModel", b =>
                {
                    b.Property<int>("DevolucionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DevolucionId"));

                    b.Property<string>("Comentarios")
                        .HasColumnType("character varying")
                        .HasColumnName("comentarios");

                    b.Property<string>("CorreoElectronicoResponsable")
                        .HasColumnType("text")
                        .HasColumnName("correo_electronico_responsable");

                    b.Property<DateOnly>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("fecha")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Motivo")
                        .HasColumnType("character varying")
                        .HasColumnName("motivo");

                    b.Property<int?>("TramiteId")
                        .HasColumnType("integer");

                    b.HasKey("DevolucionId")
                        .HasName("devoluciones_pkey");

                    b.HasIndex("TramiteId");

                    b.ToTable("devoluciones", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.DireccionModel", b =>
                {
                    b.Property<int>("DireccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("direccion_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DireccionId"));

                    b.Property<string>("Direccion")
                        .HasColumnType("character varying")
                        .HasColumnName("direccion");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("integer")
                        .HasColumnName("municipio_id");

                    b.HasKey("DireccionId")
                        .HasName("direcciones_pkey");

                    b.HasIndex("MunicipioId");

                    b.ToTable("direcciones", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.InmuebleModel", b =>
                {
                    b.Property<int>("InmuebleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("inmueble_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InmuebleId"));

                    b.Property<double?>("Area")
                        .HasColumnType("double precision")
                        .HasColumnName("area");

                    b.Property<int?>("DireccionId")
                        .HasColumnType("integer")
                        .HasColumnName("direccion_id");

                    b.Property<int?>("PropietarioId")
                        .HasColumnType("integer")
                        .HasColumnName("propietario_id");

                    b.Property<int?>("ProyectoId")
                        .HasColumnType("integer")
                        .HasColumnName("proyecto_id");

                    b.HasKey("InmuebleId")
                        .HasName("inmuebles_pkey");

                    b.HasIndex("DireccionId");

                    b.HasIndex("PropietarioId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("inmuebles", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.InstructivoModel", b =>
                {
                    b.Property<int>("InstructivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("instructivo_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("InstructivoId"));

                    b.Property<string>("Nombre")
                        .HasColumnType("character varying")
                        .HasColumnName("nombre");

                    b.HasKey("InstructivoId")
                        .HasName("instructivos_pkey");

                    b.ToTable("instructivos", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.MunicipioModel", b =>
                {
                    b.Property<int>("MunicipioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("municipio_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MunicipioId"));

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("integer")
                        .HasColumnName("departamento_id");

                    b.Property<string>("Nombre")
                        .HasColumnType("character varying")
                        .HasColumnName("nombre");

                    b.HasKey("MunicipioId")
                        .HasName("municipios_pkey");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("municipios", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.PersonaModel", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("persona_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonaId"));

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("text")
                        .HasColumnName("correo_electronico");

                    b.Property<int?>("DireccionId")
                        .HasColumnType("integer")
                        .HasColumnName("direccion_id");

                    b.Property<string>("Nombre")
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .HasColumnType("text")
                        .HasColumnName("telefono");

                    b.HasKey("PersonaId")
                        .HasName("personas_pkey");

                    b.HasIndex("DireccionId");

                    b.ToTable("personas", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.ProyectoModel", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("proyecto_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProyectoId"));

                    b.Property<int?>("EncargadoId")
                        .HasColumnType("integer")
                        .HasColumnName("encargado_id");

                    b.Property<string>("Nombre")
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.HasKey("ProyectoId")
                        .HasName("proyectos_pkey");

                    b.HasIndex("EncargadoId");

                    b.ToTable("proyectos", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.RequisitoModel", b =>
                {
                    b.Property<int>("RequisitoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("requisito_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("RequisitoId"));

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .HasColumnType("character varying")
                        .HasColumnName("descripcion");

                    b.Property<int?>("InstructivoId")
                        .HasColumnType("integer")
                        .HasColumnName("instructivo_id");

                    b.Property<string>("Nombre")
                        .HasColumnType("character varying")
                        .HasColumnName("nombre");

                    b.HasKey("RequisitoId")
                        .HasName("requisitos_pkey");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("InstructivoId");

                    b.ToTable("requisitos", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.TramiteModel", b =>
                {
                    b.Property<int>("TramiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("tramite_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("TramiteId"));

                    b.Property<string>("ArchivadoDesde")
                        .HasColumnType("character varying")
                        .HasColumnName("archivado_desde");

                    b.Property<string>("CorreoElectronicoReceptor")
                        .HasColumnType("text")
                        .HasColumnName("correo_electronico_receptor");

                    b.Property<string>("Estado")
                        .HasColumnType("character varying")
                        .HasColumnName("estado");

                    b.Property<string>("Expediente")
                        .HasColumnType("character varying")
                        .HasColumnName("expediente");

                    b.Property<DateOnly?>("FechaEgreso")
                        .HasColumnType("date")
                        .HasColumnName("fecha_egreso");

                    b.Property<DateOnly>("FechaIngreso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("fecha_ingreso")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<int?>("InmuebleId")
                        .HasColumnType("integer")
                        .HasColumnName("inmueble_id");

                    b.Property<int?>("InstructivoId")
                        .HasColumnType("integer")
                        .HasColumnName("instructivo_id");

                    b.Property<string>("Receptor")
                        .HasColumnType("character varying")
                        .HasColumnName("receptor");

                    b.HasKey("TramiteId")
                        .HasName("tramites_pkey");

                    b.HasIndex("InmuebleId");

                    b.HasIndex("InstructivoId");

                    b.ToTable("tramites", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.TramiteRequisitoModel", b =>
                {
                    b.Property<int>("TramiteRequisitoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("tramite_requisito_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TramiteRequisitoId"));

                    b.Property<bool>("Entregado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("entregado");

                    b.Property<int?>("RequisitoId")
                        .HasColumnType("integer")
                        .HasColumnName("requisito_id");

                    b.Property<int?>("TramiteId")
                        .HasColumnType("integer")
                        .HasColumnName("tramite_id");

                    b.HasKey("TramiteRequisitoId")
                        .HasName("tramites_requisitos_pkey");

                    b.HasIndex("RequisitoId");

                    b.HasIndex("TramiteId");

                    b.ToTable("tramites_requisitos", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.UsuarioModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Codigo")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Creacion")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Rol")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.VisitaModel", b =>
                {
                    b.Property<int>("VisitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("visita_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("VisitaId"));

                    b.Property<string>("Encargado")
                        .HasColumnType("character varying")
                        .HasColumnName("encargado");

                    b.Property<string>("Estado")
                        .HasColumnType("character varying")
                        .HasColumnName("estado");

                    b.Property<DateOnly?>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<DateOnly?>("FechaFinalizacion")
                        .HasColumnType("date");

                    b.Property<TimeOnly?>("Hora")
                        .HasColumnType("time without time zone")
                        .HasColumnName("hora");

                    b.Property<int?>("TramiteId")
                        .HasColumnType("integer");

                    b.HasKey("VisitaId")
                        .HasName("visitas_pkey");

                    b.HasIndex("TramiteId");

                    b.ToTable("visitas", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.UsuarioModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.UsuarioModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.UsuarioModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.UsuarioModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.ActividadModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.UsuarioModel", "Usuario")
                        .WithMany("Actividades")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("usuarios_actividades_fkey");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.DevolucionModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.TramiteModel", "Tramite")
                        .WithMany("Devoluciones")
                        .HasForeignKey("TramiteId")
                        .HasConstraintName("tramites_devoluciones_fkey");

                    b.Navigation("Tramite");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.DireccionModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.MunicipioModel", "Municipio")
                        .WithMany("Direcciones")
                        .HasForeignKey("MunicipioId")
                        .HasConstraintName("municipios_direcciones_fkey");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.InmuebleModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.DireccionModel", "Direccion")
                        .WithMany("Inmuebles")
                        .HasForeignKey("DireccionId")
                        .HasConstraintName("direcciones_inmuebles_fkey");

                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.PersonaModel", "Propietario")
                        .WithMany("Inmuebles")
                        .HasForeignKey("PropietarioId")
                        .HasConstraintName("propietarios_inmuebles_fkey");

                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.ProyectoModel", "Proyecto")
                        .WithMany("Inmuebles")
                        .HasForeignKey("ProyectoId")
                        .HasConstraintName("proyectos_inmuebles_fkey");

                    b.Navigation("Direccion");

                    b.Navigation("Propietario");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.MunicipioModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.DepartamentoModel", "Departamento")
                        .WithMany("Municipios")
                        .HasForeignKey("DepartamentoId")
                        .HasConstraintName("departamentos_municipios_fkey");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.PersonaModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.DireccionModel", "Direccion")
                        .WithMany("Personas")
                        .HasForeignKey("DireccionId")
                        .HasConstraintName("direcciones_personas_fkey");

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.ProyectoModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.PersonaModel", "Encargado")
                        .WithMany("Proyectos")
                        .HasForeignKey("EncargadoId")
                        .HasConstraintName("personas_proyectos_fkey");

                    b.Navigation("Encargado");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.RequisitoModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.CategoriaModel", "Categoria")
                        .WithMany("Requisitos")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("categorias_requisitos_fkey");

                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.InstructivoModel", "Instructivo")
                        .WithMany("Requisitos")
                        .HasForeignKey("InstructivoId")
                        .HasConstraintName("instructivos_requisitos_fkey");

                    b.Navigation("Categoria");

                    b.Navigation("Instructivo");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.TramiteModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.InmuebleModel", "Inmueble")
                        .WithMany("Tramites")
                        .HasForeignKey("InmuebleId")
                        .HasConstraintName("inmuebles_tramites_fkey");

                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.InstructivoModel", "Instructivo")
                        .WithMany("Tramites")
                        .HasForeignKey("InstructivoId")
                        .HasConstraintName("instructivos_tramites_fkey");

                    b.Navigation("Inmueble");

                    b.Navigation("Instructivo");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.TramiteRequisitoModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.RequisitoModel", "Requisito")
                        .WithMany("TramitesRequisitos")
                        .HasForeignKey("RequisitoId")
                        .HasConstraintName("tramites_requisitos_requisitos_fkey");

                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.TramiteModel", "Tramite")
                        .WithMany("TramitesRequisitos")
                        .HasForeignKey("TramiteId")
                        .HasConstraintName("tramites_requisitos_tramites_fkey");

                    b.Navigation("Requisito");

                    b.Navigation("Tramite");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.VisitaModel", b =>
                {
                    b.HasOne("RegistroTramitesOplagestTrifinio.Models.TramiteModel", "Tramite")
                        .WithMany("Visitas")
                        .HasForeignKey("TramiteId")
                        .HasConstraintName("tramites_visitas_fkey");

                    b.Navigation("Tramite");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.CategoriaModel", b =>
                {
                    b.Navigation("Requisitos");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.DepartamentoModel", b =>
                {
                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.DireccionModel", b =>
                {
                    b.Navigation("Inmuebles");

                    b.Navigation("Personas");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.InmuebleModel", b =>
                {
                    b.Navigation("Tramites");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.InstructivoModel", b =>
                {
                    b.Navigation("Requisitos");

                    b.Navigation("Tramites");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.MunicipioModel", b =>
                {
                    b.Navigation("Direcciones");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.PersonaModel", b =>
                {
                    b.Navigation("Inmuebles");

                    b.Navigation("Proyectos");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.ProyectoModel", b =>
                {
                    b.Navigation("Inmuebles");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.RequisitoModel", b =>
                {
                    b.Navigation("TramitesRequisitos");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.TramiteModel", b =>
                {
                    b.Navigation("Devoluciones");

                    b.Navigation("TramitesRequisitos");

                    b.Navigation("Visitas");
                });

            modelBuilder.Entity("RegistroTramitesOplagestTrifinio.Models.UsuarioModel", b =>
                {
                    b.Navigation("Actividades");
                });
#pragma warning restore 612, 618
        }
    }
}
