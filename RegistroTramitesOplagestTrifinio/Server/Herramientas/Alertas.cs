using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;

namespace RegistroTramitesOplagestTrifinio.Server.Herramientas
{
    public class Alertas : IAlertas
    {
        private readonly ITramitesService _tramitesService;
        private readonly IMapper _mapper;

        public Alertas(ITramitesService tramitesService, IMapper mapper)
        {
            _tramitesService = tramitesService;
            _mapper = mapper;
        }

        public async Task<AlertasDTO> ObtenerAlertas()
        {
            var limiteAproximacionAgendar = 2;
            var limiteAproximacionFirmar = 14;
            var limiteAproximacionVisitar = 2;

            var limiteRetrasoFirmar = 16;
            var limiteRetrasoVisitar = 4;
            var limiteRetrasoAgendar = 4;

            var tramitesPorAgendar = await _tramitesService.GetTramitesByEstado("Nuevo").ToListAsync();
            var tramitesPorVisitar = await _tramitesService.GetTramitesByEstado("Agendado").ToListAsync();
            var tramitesPorFirmar = await _tramitesService.GetTramitesByEstado("Visitado").ToListAsync();

            var alertaTramitesPorAgendar = tramitesPorAgendar.Where(t => ObtenerDiferenciaDeFechas(t.FechaIngreso) == limiteAproximacionAgendar).ToList();

            var alertaTramitesPorFirmar = tramitesPorFirmar.Where(t => ObtenerDiferenciaDeFechas(t.Visitas.FirstOrDefault().FechaFinalizacion) == limiteAproximacionFirmar).ToList();

            var alertaTramitesSinFirmar = tramitesPorFirmar.Where(t => ObtenerDiferenciaDeFechas(t.Visitas.FirstOrDefault().FechaFinalizacion) >= limiteRetrasoFirmar).ToList();

            var alertaTramitesSinVisitar = tramitesPorVisitar.Where(t => ObtenerDiferenciaDeFechas(t.Visitas.FirstOrDefault().Fecha) >= limiteRetrasoVisitar).ToList();

            var alertaTramitesPorVisitar = tramitesPorVisitar.Where(t => ObtenerDiferenciaDeFechas(t.Visitas.FirstOrDefault().Fecha) == limiteAproximacionVisitar).ToList();

            var alertaTramitesSinAgendar = tramitesPorAgendar.Where(t => ObtenerDiferenciaDeFechas(t.FechaIngreso) >= limiteRetrasoAgendar).ToList();

            var alerta = new AlertasDTO();

            alerta.TramitesPorAgendar.AddRange(_mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(alertaTramitesPorAgendar ??= new List<TramiteModel>()));
            alerta.TramitesPorFirmar.AddRange(_mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(alertaTramitesPorFirmar ??= new List<TramiteModel>()));
            alerta.TramitesSinFirmar.AddRange(_mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(alertaTramitesSinFirmar ??= new List<TramiteModel>() ));
            alerta.TramitesSinVisitar.AddRange(_mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(alertaTramitesSinVisitar ??= new List<TramiteModel>()));
            alerta.TramitesPorVisitar.AddRange(_mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(alertaTramitesPorVisitar ??= new List<TramiteModel>()));
            alerta.TramitesSinAgendar.AddRange(_mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(alertaTramitesSinAgendar ??= new List<TramiteModel>()));

            return alerta;
        }

        private int ObtenerDiferenciaDeFechas(DateOnly? fecha)
        {
            var dias = 0;

            if (fecha is not null)
            {
                dias = DateOnly.FromDateTime(DateTime.Today).DayNumber - fecha.Value.DayNumber;
            }

            return dias;
        }
    }

    public interface IAlertas
    {
        Task<AlertasDTO> ObtenerAlertas();
    }
}
