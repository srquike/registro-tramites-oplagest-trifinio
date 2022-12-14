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
        private readonly IMapper _mapper;

        public InmueblesController(ITramitesService tramitesService, IMapper mapper)
        {
            _tramitesService = tramitesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<InmuebleDTO>>> GetInmuebles() 
        {
            var inmuebles = await _tramitesService.GetInmueblesAsync();

            return _mapper.Map<List<InmuebleModel>, List<InmuebleDTO>>(inmuebles);
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
    }
}
