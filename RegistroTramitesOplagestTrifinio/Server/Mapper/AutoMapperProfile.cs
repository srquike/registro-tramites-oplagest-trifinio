using AutoMapper;
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
                .ForPath(d => d.Encargado, options => options.MapFrom(s => s.Inmueble.Proyecto.Encargado.Nombre))
                .ForPath(d => d.Proyecto, options => options.MapFrom(s => s.Inmueble.Proyecto.Nombre))
                .ForPath(d => d.Municipio, options => options.MapFrom(s => s.Inmueble.Direccion.Municipio.Nombre));

            CreateMap<InstructivoDTO, InstructivoModel>().ReverseMap();

            CreateMap<RequisitoDTO, RequisitoModel>().ReverseMap();

            CreateMap<FormularioTramiteDTO, TramiteModel>().ReverseMap();

            CreateMap<TramiteModel, TramiteDTO>()
                .ForPath(d => d.Instructivo, options => options.MapFrom(s => s.Instructivo.Nombre))
                .ForPath(d => d.MontoPagado, options => options.MapFrom(s => s.MontoPagado))
                .ForPath(d => d.FechaEgreso, options => options.MapFrom(s => s.FechaEgreso.Value.ToString()))
                .ForPath(d => d.Proyecto, options => options.MapFrom(s => s.Inmueble.Proyecto.Nombre))
                .ForPath(d => d.Encargado, options => options.MapFrom(s => s.Inmueble.Proyecto.Encargado.Nombre))
                .ForPath(d => d.EncargadoTelefono, options => options.MapFrom(s => s.Inmueble.Proyecto.Encargado.Telefono))
                .ForPath(d => d.Propietario, options => options.MapFrom(s => s.Inmueble.Propietario.Nombre))
                .ForPath(d => d.PropietarioTelefono, options => options.MapFrom(s => s.Inmueble.Propietario.Telefono))
                .ForPath(d => d.CorreoElectronico, options => options.MapFrom(s => s.Inmueble.Propietario.CorreoElectronico))
                .ForPath(d => d.FechaIngreso, options => options.MapFrom(s => s.FechaIngreso.ToString()))
                .ForPath(d => d.InmuebleDireccion, options => options.MapFrom(s => ObtenerDireccion(s.Inmueble.Direccion)))       
                .ForPath(d => d.PropietarioDireccion, options => options.MapFrom(s => ObtenerDireccion(s.Inmueble.Propietario.Direccion)));

            CreateMap<TramiteRequisitoDTO, TramiteRequisitoModel>();

            CreateMap<TramiteRequisitoModel, TramiteRequisitoDTO>()
                .ForPath(d => d.Nombre, options => options.MapFrom(s => s.Requisito.Nombre));

            CreateMap<VisitaDTO, VisitaModel>().ReverseMap();

            CreateMap<DevolucionDTO, DevolucionModel>().ReverseMap();

            CreateMap<ActividadDTO, ActividadModel>().ReverseMap();

            CreateMap<DepartamentoDTO, DepartamentoModel>().ReverseMap();

            CreateMap<MunicipioDTO, MunicipioModel>().ReverseMap();

            CreateMap<DireccionDTO, DireccionModel>().ReverseMap();

            CreateMap<ProyectoDTO, ProyectoModel>()
                .ForPath(d => d.Encargado.Nombre, options => options.MapFrom(s => s.Encargado))
                .ForPath(d => d.Encargado.Telefono, options => options.MapFrom(s => s.Telefono))
                .ForPath(d => d.Encargado.CorreoElectronico, options => options.MapFrom(s => s.CorreoElectronico))
                .ReverseMap();

            CreateMap<PersonaDTO, PersonaModel>().ReverseMap();

            CreateMap<InmuebleDTO, InmuebleModel>().ReverseMap();

            CreateMap<InmuebleModel, InmuebleListadoDTO>()
                .ForPath(d => d.Direccion, options => options.MapFrom(s => ObtenerDireccion(s.Direccion)))
                .ForPath(d => d.Proyecto, options => options.MapFrom(s => s.Proyecto.Nombre))
                .ForPath(d => d.Propietario, options => options.MapFrom(s => s.Propietario.Nombre));

            CreateMap<UsuarioModel, UsuarioListaDTO>()
                .ForMember(d => d.UsuarioId, options => options.MapFrom(s => s.Id))
                .ForMember(d => d.Nombre, options => options.MapFrom(s => s.Nombre))
                .ForMember(d => d.CorreoElectronico, options => options.MapFrom(s => s.Email))
                .ForMember(d => d.Activo, options => options.MapFrom(s => s.Activo))
                .ForMember(d => d.FechaCreacion, options => options.MapFrom(s => s.Creacion))
                .ForPath(d => d.Rol, options => options.MapFrom(s => s.UsuariosRoles.FirstOrDefault().Role.Name));
        }

        private string ObtenerDireccion(DireccionModel direccion)
        {
            if (direccion is null)
            {
                return string.Empty;
            }

            var municipio = direccion.Municipio.Nombre;
            var departamento = direccion.Municipio.Departamento.Nombre;

            return $"{direccion.Direccion}, {municipio}, {departamento}";
        }
    }
}