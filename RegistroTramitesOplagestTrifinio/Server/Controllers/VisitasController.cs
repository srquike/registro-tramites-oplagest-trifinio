using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Visitas;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitasController : ControllerBase
    {
        private readonly IVisitasService _visitasService;
        private readonly IMapper _mapper;

        public VisitasController(IVisitasService visitasService, IMapper mapper)
        {
            _visitasService = visitasService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VisitaDTO>>> Get()
        {
            return _mapper.Map<List<VisitaModel>, List<VisitaDTO>>(await _visitasService.GetVisitasAsync());
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
    }
}