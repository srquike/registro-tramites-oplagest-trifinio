using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Inmuebles;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly IInmueblesService _inmueblesService;
        private readonly IPersonasService _personasService;
        private readonly IDireccionesService _direccionesService;
        private readonly IMapper _mapper;

        public InmueblesController(IMapper mapper, IInmueblesService inmueblesService, IPersonasService personasService, IDireccionesService direccionesService)
        {
            _mapper = mapper;
            _inmueblesService = inmueblesService;
            _personasService = personasService;
            _direccionesService = direccionesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InmuebleListadoDTO>>> GetInmuebles() 
        {
            var inmuebles = await _inmueblesService.GetInmueblesAsync();

            return _mapper.Map<List<InmuebleModel>, List<InmuebleListadoDTO>>(inmuebles);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] InmuebleDTO dTO)
        {
            var inmueble = _mapper.Map<InmuebleDTO, InmuebleModel>(dTO);
            var inmuebleId = await _inmueblesService.CreateAsync(inmueble);

            if (inmuebleId <= 0)
            {
                return BadRequest();
            }

            return inmuebleId;
        }

        [HttpGet("{inmuebleId:int}")]
        public async Task<ActionResult<InmuebleDTO>> GetInmueble(int inmuebleId)
        {
            if (await _inmueblesService.GetInmuebleAsync(inmuebleId) is var inmueble)
            {
                return _mapper.Map<InmuebleModel, InmuebleDTO>(inmueble);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult> EditarInmueble([FromBody] InmuebleDTO dTO)
        {
            var inmueble = _mapper.Map<InmuebleDTO, InmuebleModel>(dTO);

            if (await _inmueblesService.GetInmuebleAsync(inmueble.InmuebleId) is not null)
            {
                if (await _inmueblesService.UpdateAsync(inmueble) > 0)
                {
                    await _personasService.UpdateAsync(_mapper.Map<PersonaDTO, PersonaModel>(dTO.Propietario));
                    //await _direccionesService.UpdateAsync(_mapper.Map<DireccionDTO, DireccionModel>(dTO.Direccion));
                    //await _direccionesService.UpdateAsync(_mapper.Map<DireccionDTO, DireccionModel>(dTO.Propietario.Direccion));

                    return NoContent();
                }

                return BadRequest();
            }

            return NotFound();
        }
    }
}
