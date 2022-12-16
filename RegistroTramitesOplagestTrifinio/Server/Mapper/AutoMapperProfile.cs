using AutoMapper;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Instructivos;
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
                .ForMember(d => d.PasswordHash, opt => opt.MapFrom(s => s.Clave))
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

            CreateMap<TramiteListaDTO, TramiteModel>().ReverseMap();

            CreateMap<InstructivoDTO, InstructivoModel>().ReverseMap();

            CreateMap<RequisitoDTO, RequisitoModel>()
                .ForPath(d => d.Categoria.Nombre, opt => opt.MapFrom(s => s.Categoria))
                .ReverseMap();

            CreateMap<TramiteDTO, TramiteModel>()
                .ForPath(d => d.Instructivo.Nombre, opt => opt.MapFrom(s => s.Instructivo))
                .ReverseMap();
            
            CreateMap<TramiteVerDTO, TramiteModel>()
                .ForPath(d => d.Instructivo.Nombre, opt => opt.MapFrom(s => s.Instructivo))
                .ReverseMap();

            CreateMap<TramiteRequisitoDTO, TramiteRequisitoModel>()
                .ForPath(d => d.Requisito.Nombre, opt => opt.MapFrom(s => s.Nombre))
                .ReverseMap();

            CreateMap<VisitaDTO, VisitaModel>().ReverseMap();

            CreateMap<DevolucionDTO, DevolucionModel>().ReverseMap();
        }
    }
}