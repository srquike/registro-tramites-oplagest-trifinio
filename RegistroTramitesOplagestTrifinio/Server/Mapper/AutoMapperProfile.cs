using AutoMapper;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios;

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
        }
    }
}