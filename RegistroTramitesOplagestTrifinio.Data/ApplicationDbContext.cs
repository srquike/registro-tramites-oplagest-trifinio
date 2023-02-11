using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Data
{
    public class ApplicationDbContext : IdentityDbContext<UsuarioModel, RolModel, string, IdentityUserClaim<string>, UsuarioRolModel, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public virtual DbSet<ActividadModel> Actividades { get; set; }
        public virtual DbSet<InstructivoModel> Instructivos { get; set; }
        public virtual DbSet<RequisitoModel> Requisitos { get; set; }
        public virtual DbSet<TramiteModel> Tramites { get; set; }
        public virtual DbSet<VisitaModel> Visitas { get; set; }
        public virtual DbSet<TramiteRequisitoModel> TramitesRequisitos { get; set; }
        public virtual DbSet<CategoriaModel> Categorias { get; set; }
        public virtual DbSet<DevolucionModel> Devoluciones { get; set; }
        public virtual DbSet<DepartamentoModel> Departamentos { get; set; }
        public virtual DbSet<MunicipioModel> Municipios { get; set; }
        public virtual DbSet<DireccionModel> Direcciones { get; set; }
        public virtual DbSet<InmuebleModel> Inmuebles { get; set; }
        public virtual DbSet<PersonaModel> Personas { get; set; }
        public virtual DbSet<ProyectoModel> Proyectos { get; set; }
        public virtual DbSet<UsuarioModel> AspNetUsers { get; set; }
        public virtual DbSet<UsuarioRolModel> UsuarioRoles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UsuarioModel>(entity =>
            {
                entity.HasMany(p => p.UsuariosRoles).WithOne(d => d.User)
                    .HasForeignKey(d => d.UserId)
                    .IsRequired();
            });
            
            builder.Entity<RolModel>(entity =>
            {
                entity.HasMany(p => p.UsuariosRoles).WithOne(d => d.Role)
                    .HasForeignKey(d => d.RoleId)
                    .IsRequired();
            });

            builder.Entity<ProyectoModel>(entity =>
            {
                entity.HasKey(e => e.ProyectoId).HasName("proyectos_pkey");
                entity.ToTable("proyectos");
                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre");
                entity.Property(e => e.ProyectoId)
                    .HasColumnName("proyecto_id");
                entity.Property(e => e.EncargadoId)
                    .HasColumnName("encargado_id");

                entity.HasOne(d => d.Encargado).WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.EncargadoId)
                    .HasConstraintName("personas_proyectos_fkey")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<PersonaModel>(entity =>
            {
                entity.HasKey(e => e.PersonaId).HasName("personas_pkey");
                entity.ToTable("personas");
                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre");
                entity.Property(e => e.CorreoElectronico)
                    .HasColumnName("correo_electronico");
                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono");
                entity.Property(e => e.PersonaId)
                    .HasColumnName("persona_id");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion");

                //entity.Property(e => e.DireccionId)
                //    .HasColumnName("direccion_id");

                //entity.HasOne(d => d.Direccion).WithMany(p => p.Personas)
                //    .HasForeignKey(d => d.DireccionId)
                //    .HasConstraintName("direcciones_personas_fkey")
                //    .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<InmuebleModel>(entity =>
            {
                entity.HasKey(e => e.InmuebleId).HasName("inmuebles_pkey");
                entity.ToTable("inmuebles");
                entity.Property(e => e.Area)
                    .HasColumnName("area");
                entity.Property(e => e.PropietarioId)
                    .HasColumnName("propietario_id");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion");

                //entity.Property(e => e.DireccionId)
                //    .HasColumnName("direccion_id");
                entity.Property(e => e.InmuebleId)
                    .HasColumnName("inmueble_id");
                entity.Property(e => e.ProyectoId)
                    .HasColumnName("proyecto_id");

                entity.HasOne(d => d.Propietario).WithMany(p => p.Inmuebles)
                    .HasForeignKey(d => d.PropietarioId)
                    .HasConstraintName("propietarios_inmuebles_fkey")
                    .OnDelete(DeleteBehavior.SetNull);

                //entity.HasOne(d => d.Direccion).WithMany(p => p.Inmuebles)
                //    .HasForeignKey(d => d.DireccionId)
                //    .HasConstraintName("direcciones_inmuebles_fkey")
                //    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Proyecto).WithMany(p => p.Inmuebles)
                    .HasForeignKey(d => d.ProyectoId)
                    .HasConstraintName("proyectos_inmuebles_fkey")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<DepartamentoModel>(entity =>
            {
                entity.HasKey(e => e.DepartamentoId).HasName("departamentos_pkey");
                entity.ToTable("departamentos");
                entity.Property(e => e.Nombre)
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");
                entity.Property(e => e.Iso)
                    .HasColumnType("character varying")
                    .HasColumnName("iso");
            });

            builder.Entity<MunicipioModel>(entity =>
            {
                entity.HasKey(e => e.MunicipioId).HasName("municipios_pkey");
                entity.ToTable("municipios");
                entity.Property(e => e.Nombre)
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");
                entity.Property(e => e.MunicipioId)
                    .HasColumnName("municipio_id");

                entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");

                entity.HasOne(d => d.Departamento).WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("departamentos_municipios_fkey");
            });

            builder.Entity<DevolucionModel>(entity =>
            {
                entity.HasKey(e => e.DevolucionId).HasName("devoluciones_pkey");
                entity.ToTable("devoluciones");
                entity.Property(e => e.Motivo)
                    .HasColumnType("character varying")
                    .HasColumnName("motivo");
                entity.Property(e => e.Comentarios)
                    .HasColumnType("character varying")
                    .HasColumnName("comentarios");
                entity.Property(e => e.Etapa)
                    .HasColumnType("character varying")
                    .HasColumnName("etapa");
                entity.Property(e => e.Fecha)
                    .HasDefaultValueSql("CURRENT_DATE")
                    .HasColumnName("fecha");
                entity.Property(e => e.CorreoElectronicoResponsable).HasColumnName("correo_electronico_responsable");

                entity.HasOne(d => d.Tramite).WithMany(p => p.Devoluciones)
                    .HasForeignKey(d => d.TramiteId)
                    .HasConstraintName("tramites_devoluciones_fkey")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CategoriaModel>(entity =>
            {
                entity.HasKey(e => e.CategoriaId).HasName("categorias_pkey");
                entity.ToTable("categorias");
                entity.Property(e => e.Nombre)
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");
            });

            builder.Entity<TramiteRequisitoModel>(entity =>
            {
                entity.HasKey(e => e.TramiteRequisitoId).HasName("tramites_requisitos_pkey");
                entity.ToTable("tramites_requisitos");
                entity.Property(e => e.Entregado)
                    .HasColumnType("boolean")
                    .HasDefaultValue("false")
                    .HasColumnName("entregado");
                entity.Property(e => e.RequisitoId)
                    .HasColumnName("requisito_id");
                entity.Property(e => e.TramiteId)
                    .HasColumnName("tramite_id");
                entity.Property(e => e.TramiteRequisitoId)
                    .HasColumnName("tramite_requisito_id");

                entity.HasOne(d => d.Tramite).WithMany(p => p.TramitesRequisitos)
                    .HasForeignKey(d => d.TramiteId)
                    .HasConstraintName("tramites_requisitos_tramites_fkey")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Requisito).WithMany(p => p.TramitesRequisitos)
                    .HasForeignKey(d => d.RequisitoId)
                    .HasConstraintName("tramites_requisitos_requisitos_fkey");
            });

            builder.Entity<ActividadModel>(entity =>
            {
                entity.HasKey(e => e.ActividadId).HasName("actividades_pkey");

                entity.ToTable("actividades");

                entity.Property(e => e.ActividadId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("actividad_id");
                entity.Property(e => e.Fecha)
                    .HasDefaultValueSql("CURRENT_DATE")
                    .HasColumnName("fecha");
                entity.Property(e => e.Hora)
                    .HasDefaultValueSql("CURRENT_TIME")
                    .HasColumnName("hora");
                entity.Property(e => e.Resumen)
                    .HasColumnType("character varying")
                    .HasColumnName("resumen");
                entity.Property(e => e.NombreUsuario)
                    .HasColumnType("character varying")
                    .HasColumnName("usuario");
                entity.HasOne(d => d.Usuario).WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("usuarios_actividades_fkey");
            });

            builder.Entity<InstructivoModel>(entity =>
            {
                entity.HasKey(e => e.InstructivoId).HasName("instructivos_pkey");

                entity.ToTable("instructivos");

                entity.Property(e => e.InstructivoId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("instructivo_id");
                entity.Property(e => e.Nombre)
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");
            });

            builder.Entity<RequisitoModel>(entity =>
            {
                entity.HasKey(e => e.RequisitoId).HasName("requisitos_pkey");

                entity.ToTable("requisitos");

                entity.Property(e => e.RequisitoId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("requisito_id");
                entity.Property(e => e.Descripcion)
                    .HasColumnType("character varying")
                    .HasColumnName("descripcion");
                entity.Property(e => e.InstructivoId).HasColumnName("instructivo_id");
                entity.Property(e => e.Nombre)
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Instructivo).WithMany(p => p.Requisitos)
                    .HasForeignKey(d => d.InstructivoId)
                    .HasConstraintName("instructivos_requisitos_fkey");

                entity.HasOne(d => d.Categoria).WithMany(p => p.Requisitos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("categorias_requisitos_fkey");
            });

            builder.Entity<TramiteModel>(entity =>
            {
                entity.HasKey(e => e.TramiteId).HasName("tramites_pkey");

                entity.ToTable("tramites");

                entity.Property(e => e.TramiteId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("tramite_id");
                entity.Property(e => e.MontoPagado)
                    .HasColumnName("monto_pagado");
                entity.Property(e => e.ArchivadoDesde)
                    .HasColumnType("character varying")
                    .HasColumnName("archivado_desde");
                entity.Property(e => e.Estado)
                    .HasColumnType("character varying")
                    .HasColumnName("estado");
                entity.Property(e => e.FechaEgreso).HasColumnName("fecha_egreso");
                entity.Property(e => e.FechaIngreso)
                    .HasDefaultValueSql("CURRENT_DATE")
                    .HasColumnName("fecha_ingreso");
                entity.Property(e => e.InstructivoId).HasColumnName("instructivo_id");
                entity.Property(e => e.InmuebleId).HasColumnName("inmueble_id");
                entity.Property(e => e.Receptor)
                    .HasColumnType("character varying")
                    .HasColumnName("receptor");
                entity.Property(e => e.Expediente)
                    .HasColumnType("character varying")
                    .HasColumnName("expediente");
                entity.Property(e => e.CorreoElectronicoReceptor).HasColumnName("correo_electronico_receptor");

                entity.HasOne(d => d.Instructivo).WithMany(p => p.Tramites)
                    .HasForeignKey(d => d.InstructivoId)
                    .HasConstraintName("instructivos_tramites_fkey")
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Inmueble).WithMany(p => p.Tramites)
                    .HasForeignKey(d => d.InmuebleId)
                    .HasConstraintName("inmuebles_tramites_fkey")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<VisitaModel>(entity =>
            {
                entity.HasKey(e => e.VisitaId).HasName("visitas_pkey");
                entity.ToTable("visitas");
                entity.Property(e => e.VisitaId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("visita_id");
                entity.Property(e => e.Encargado)
                    .HasColumnType("character varying")
                    .HasColumnName("encargado");
                entity.Property(e => e.Estado)
                    .HasColumnType("character varying")
                    .HasColumnName("estado");
                entity.Property(e => e.Comentarios)
                    .HasColumnType("character varying")
                    .HasColumnName("comentarios");
                entity.Property(e => e.Fecha).HasColumnName("fecha");
                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.HasOne(d => d.Tramite).WithMany(p => p.Visitas)
                    .HasForeignKey(d => d.TramiteId)
                    .HasConstraintName("tramites_visitas_fkey")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<DireccionModel>(entity =>
            {
                entity.HasKey(e => e.DireccionId).HasName("direcciones_pkey");
                entity.ToTable("direcciones");
                entity.Property(e => e.DireccionId).HasColumnName("direccion_id");
                entity.Property(e => e.Direccion)
                    .HasColumnType("character varying")
                    .HasColumnName("direccion");
                entity.Property(e => e.MunicipioId).HasColumnName("municipio_id");

                entity.HasOne(d => d.Municipio).WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.MunicipioId)
                    .HasConstraintName("municipios_direcciones_fkey");
            });

        }
    }
}