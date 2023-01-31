using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Inmuebles;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly ITramitesService _tramitesService;
        private readonly IInmueblesService _inmueblesService;
        private readonly IMapper _mapper;

        public InmueblesController(ITramitesService tramitesService, IMapper mapper, IInmueblesService inmueblesService)
        {
            _tramitesService = tramitesService;
            _mapper = mapper;
            _inmueblesService = inmueblesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InmuebleListadoDTO>>> GetInmuebles() 
        {
            var inmuebles = await _tramitesService.GetInmueblesAsync();

            return _mapper.Map<List<InmuebleModel>, List<InmuebleListadoDTO>>(inmuebles);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] InmuebleDTO dTO)
        {
            var inmueble = _mapper.Map<InmuebleDTO, InmuebleModel>(dTO);
            var inmuebleId = await _tramitesService.CreateInmuebleAsync(inmueble);

            if (inmuebleId <= 0)
            {
                return BadRequest();
            }

            return inmuebleId;
        }

        [HttpGet("{inmuebleId:int}")]
        public async Task<ActionResult<InmuebleDTO>> GetInmueble(int inmuebleId)
        {
            if (await _tramitesService.GetInmuebleAsync(inmuebleId) is var inmueble)
            {
                return _mapper.Map<InmuebleModel, InmuebleDTO>(inmueble);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult> EditarInmueble([FromBody] InmuebleDTO dTO)
        {
            var inmueble = _mapper.Map<InmuebleDTO, InmuebleModel>(dTO);

            if (await _tramitesService.GetInmuebleAsync(inmueble.InmuebleId) is not null)
            {
                if (await _tramitesService.UpdateInmuebleAsync(inmueble) > 0)
                {
                    return NoContent();
                }

                return BadRequest();
            }

            return NotFound();
        }
    }
}
