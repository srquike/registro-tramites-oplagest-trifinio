using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Data;

public partial class OplagestDbContext : DbContext
{

    public OplagestDbContext( )
    {
    }

    public OplagestDbContext(DbContextOptions<OplagestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActividadModel> Actividades { get; set; }

    public virtual DbSet<InstructivoModel> Instructivos { get; set; }

    public virtual DbSet<RequisitoModel> Requisitos { get; set; }

    public virtual DbSet<TramiteModel> Tramites { get; set; }

    public virtual DbSet<UsuarioModel> Usuarios { get; set; }

    public virtual DbSet<VisitaModel> Visitas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");
        });

        modelBuilder.Entity<ActividadModel>(entity =>
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
        });

        modelBuilder.Entity<InstructivoModel>(entity =>
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

        modelBuilder.Entity<RequisitoModel>(entity =>
        {
            entity.HasKey(e => e.RequesitoId).HasName("requisitos_pkey");

            entity.ToTable("requisitos");

            entity.Property(e => e.RequesitoId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("requesito_id");
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

        modelBuilder.Entity<TramiteModel>(entity =>
        {
            entity.HasKey(e => e.TramiteId).HasName("tramites_pkey");

            entity.ToTable("tramites");

            entity.Property(e => e.TramiteId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("tramite_id");
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

            entity.HasOne(d => d.Instructivo).WithMany(p => p.Tramites)
                .HasForeignKey(d => d.InstructivoId)
                .HasConstraintName("instructivos_tramites_fkey");
        });

        modelBuilder.Entity<UsuarioModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Creacion)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("creacion");
        });

        modelBuilder.Entity<VisitaModel>(entity =>
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

        OnModelCreatingPartial(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
