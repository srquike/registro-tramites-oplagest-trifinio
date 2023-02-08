using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Server.Extensiones;
using RegistroTramitesOplagestTrifinio.Server.Herramientas;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Visitas;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VisitasController : ControllerBase
    {
        private readonly IVisitasService _visitasService;
        private readonly ITramitesService _tramitesService;
        private readonly IMapper _mapper;

        public VisitasController(IVisitasService visitasService, IMapper mapper, ITramitesService tramitesService)
        {
            _visitasService = visitasService;
            _mapper = mapper;
            _tramitesService = tramitesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VisitaDTO>>> Get([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _visitasService.GetVisitasAsync();
            var visitas = await queryable.OrderByDescending(v => v.Fecha).Paginar(paginacion).ToListAsync();

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.Cantidad);

            return _mapper.Map<List<VisitaModel>, List<VisitaDTO>>(visitas);
        }

        [HttpGet("{VisitaId:int}")]
        public async Task<ActionResult<VisitaDTO>> Get(int VisitaId)
        {
            return _mapper.Map<VisitaModel, VisitaDTO>(await _visitasService.GetVisitaAsync(VisitaId));
        }

        [HttpPut("{VisitaId:int}")]
        public async Task<ActionResult> Put([FromBody] VisitaDTO visita, int VisitaId)
        {
            if (await _visitasService.GetVisitaAsync(VisitaId) is not null)
            {
                if (await _visitasService.UpdateAsync(_mapper.Map<VisitaDTO, VisitaModel>(visita)) > 0)
                {
                    return NoContent();
                }

                return BadRequest();
            }

            return NotFound();
        }

        [HttpPut("completar/{visitaId:int}")]
        public async Task<IActionResult> Completar([FromBody] int tramiteId, int visitaId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var tramite)
            {
                tramite.Estado = "Visitado";

                if (await _tramitesService.Update(tramite) > 0)
                {
                    if (await _visitasService.GetVisitaAsync(visitaId) is var visita)
                    {
                        visita.Estado = "Realizada";
                        visita.FechaFinalizacion = DateOnly.FromDateTime(DateTime.Today);

                        if (await _visitasService.UpdateAsync(visita) > 0)
                        {
                            return NoContent();
                        }

                        return BadRequest();
                    }
                }
            }

            return NotFound();
        }
    }
}