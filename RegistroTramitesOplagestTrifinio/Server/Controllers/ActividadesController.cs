using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Server.Extensiones;
using RegistroTramitesOplagestTrifinio.Server.Herramientas;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Actividades;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadesService _actividadesService;
        private readonly IMapper _mapper;

        public ActividadesController(IActividadesService actividadesService, IMapper mapper)
        {
            _actividadesService = actividadesService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ActividadDTO actividad)
        {
            if (await _actividadesService.CreateAsync(_mapper.Map<ActividadDTO, ActividadModel>(actividad)) > 0)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<List<ActividadDTO>> Get([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _actividadesService.GetActividadesQueryable();
            var actividades = await queryable.OrderByDescending(a => a.Fecha).Paginar(paginacion).ToListAsync();

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.Cantidad);

            return _mapper.Map<List<ActividadModel>, List<ActividadDTO>>(actividades);
        }
    }
}