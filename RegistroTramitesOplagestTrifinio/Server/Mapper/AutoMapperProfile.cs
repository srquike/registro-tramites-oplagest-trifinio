﻿using AutoMapper;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Actividades;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Inmuebles;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Instructivos;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Proyectos;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Requisitos;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Visitas;

namespace RegistroTramitesOplagestTrifinio.Server.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioFormularioDTO, UsuarioModel>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.CorreoElectronico))
                .ReverseMap();

            CreateMap<UsuarioIngresarDTO, UsuarioModel>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.CorreoElectronico))
                .ForMember(d => d.PasswordHash, opt => opt.MapFrom(s => s.Clave))
                .ReverseMap();

            CreateMap<UsuarioListaDTO, UsuarioModel>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.CorreoElectronico))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UsuarioId))
                .ForMember(d => d.Creacion, opt => opt.MapFrom(s => s.FechaCreacion))
                .ReverseMap();

            CreateMap<TramiteModel, TramiteListaDTO>()
                .ForPath(d => d.Proyecto, options => options.MapFrom(s => s.Proyecto.Nombre))
                .ForPath(d => d.Encargado, options => options.MapFrom(s => s.Proyecto.Encargado.Nombre))
                .ForPath(d => d.Municipio, options => options.MapFrom(s => s.Inmueble.Direccion.Municipio.Nombre));

            CreateMap<InstructivoDTO, InstructivoModel>().ReverseMap();

            CreateMap<RequisitoDTO, RequisitoModel>().ReverseMap();

            CreateMap<FormularioTramiteDTO, TramiteModel>().ReverseMap();

            CreateMap<TramiteModel, TramiteDTO>()
                .ForPath(d => d.Instructivo, options => options.MapFrom(s => s.Instructivo.Nombre))
                .ForPath(d => d.FechaEgreso, options => options.MapFrom(s => s.FechaEgreso.Value.ToString()))
                .ForPath(d => d.Encargado, options => options.MapFrom(s => s.Proyecto.Encargado.Nombre))
                .ForPath(d => d.Proyecto, options => options.MapFrom(s => s.Proyecto.Nombre))
                .ForPath(d => d.EncargadoTelefono, options => options.MapFrom(s => s.Proyecto.Encargado.Telefono))
                .ForPath(d => d.Propietario, options => options.MapFrom(s => s.Inmueble.Propietario.Nombre))
                .ForPath(d => d.PropietarioTelefono, options => options.MapFrom(s => s.Inmueble.Propietario.Telefono))
                .ForPath(d => d.CorreoElectronico, options => options.MapFrom(s => s.Inmueble.Propietario.CorreoElectronico))
                .ForPath(d => d.FechaIngreso, options => options.MapFrom(s => s.FechaIngreso.ToString()))
                .ForPath(d => d.InmuebleDireccion, options => options.MapFrom(s =>
                    $"{s.Inmueble.Direccion.Direccion}, {s.Inmueble.Direccion.Municipio.Nombre}, {s.Inmueble.Direccion.Municipio.Departamento.Nombre}"
                ))
                .ForPath(d => d.PropietarioDireccion, options => options.MapFrom(s =>
                    $"{s.Proyecto.Encargado.Direccion.Direccion}, {s.Proyecto.Encargado.Direccion.Municipio.Nombre}, {s.Proyecto.Encargado.Direccion.Municipio.Departamento.Nombre}"
                ));

            CreateMap<TramiteRequisitoDTO, TramiteRequisitoModel>().ReverseMap();

            CreateMap<VisitaDTO, VisitaModel>().ReverseMap();

            CreateMap<DevolucionDTO, DevolucionModel>().ReverseMap();

            CreateMap<ActividadDTO, ActividadModel>().ReverseMap();

            CreateMap<DepartamentoDTO, DepartamentoModel>().ReverseMap();

            CreateMap<MunicipioDTO, MunicipioModel>().ReverseMap();

            CreateMap<DireccionDTO, DireccionModel>().ReverseMap();

            CreateMap<ProyectoDTO, ProyectoModel>().ReverseMap();

            CreateMap<PersonaDTO, PersonaModel>().ReverseMap();

            CreateMap<InmuebleDTO, InmuebleModel>().ReverseMap();
        }
    }
}