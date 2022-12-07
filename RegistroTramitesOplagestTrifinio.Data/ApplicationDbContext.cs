﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Data
{
    public class ApplicationDbContext : IdentityDbContext<UsuarioModel>
    {
        public virtual DbSet<ActividadModel> Actividades { get; set; }
        public virtual DbSet<InstructivoModel> Instructivos { get; set; }
        public virtual DbSet<RequisitoModel> Requisitos { get; set; }
        public virtual DbSet<TramiteModel> Tramites { get; set; }
        public virtual DbSet<VisitaModel> Visitas { get; set; }
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
                entity.HasKey(e => e.RequesitoId).HasName("requisitos_pkey");

                entity.ToTable("requisitos");

                entity.Property(e => e.RequesitoId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("requesito_id");
                entity.Property(e => e.Adicional).HasColumnName("adicional");
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
            });

            builder.Entity<TramiteModel>(entity =>
            {
                entity.HasKey(e => e.TramiteId).HasName("tramites_pkey");

                entity.ToTable("tramites");

                entity.Property(e => e.TramiteId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("tramite_id");
                entity.Property(e => e.ArchivadoDesde)
                    .HasColumnType("character varying")
                    .HasColumnName("archivado_desde");
                entity.Property(e => e.Departamento)
                    .HasColumnType("character varying")
                    .HasColumnName("departamento");
                entity.Property(e => e.Direccion)
                    .HasColumnType("character varying")
                    .HasColumnName("direccion");
                entity.Property(e => e.Estado)
                    .HasColumnType("character varying")
                    .HasColumnName("estado");
                entity.Property(e => e.FechaEgreso).HasColumnName("fecha_egreso");
                entity.Property(e => e.FechaIngreso)
                    .HasDefaultValueSql("CURRENT_DATE")
                    .HasColumnName("fecha_ingreso");
                entity.Property(e => e.InstructivoId).HasColumnName("instructivo_id");
                entity.Property(e => e.MotivoDevolucion)
                    .HasColumnType("character varying")
                    .HasColumnName("motivo_devolucion");
                entity.Property(e => e.Municipio)
                    .HasColumnType("character varying")
                    .HasColumnName("municipio");
                entity.Property(e => e.Propietario)
                    .HasColumnType("character varying")
                    .HasColumnName("propietario");
                entity.Property(e => e.Proyecto)
                    .HasColumnType("character varying")
                    .HasColumnName("proyecto");
                entity.Property(e => e.Receptor)
                    .HasColumnType("character varying")
                    .HasColumnName("receptor");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .IsFixedLength()
                    .HasColumnName("telefono");
                entity.Property(e => e.TipoConstruccion)
                    .HasColumnType("character varying")
                    .HasColumnName("tipo_construccion");
                entity.Property(e => e.TipoProyecto)
                    .HasColumnType("character varying")
                    .HasColumnName("tipo_proyecto");
                entity.Property(e => e.TipoTramite)
                    .HasColumnType("character varying")
                    .HasColumnName("tipo_tramite");
                entity.Property(e => e.VisitaId).HasColumnName("visita_id");

                entity.HasOne(d => d.Instructivo).WithMany(p => p.Tramites)
                    .HasForeignKey(d => d.InstructivoId)
                    .HasConstraintName("instructivos_tramites_fkey");

                entity.HasOne(d => d.Visita).WithMany(p => p.Tramites)
                    .HasForeignKey(d => d.VisitaId)
                    .HasConstraintName("visitas_tramites_fkey");
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
                entity.Property(e => e.Fecha).HasColumnName("fecha");
                entity.Property(e => e.Hora).HasColumnName("hora");
            });

            base.OnModelCreating(builder);
        }
    }
}