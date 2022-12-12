using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TramitesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITramitesService _tramitesService;

        public TramitesController(IMapper mapper, ITramitesService tramitesService)
        {
            _mapper = mapper;
            _tramitesService = tramitesService;
        }

        // GET: api/<TramitesController>
        [HttpGet]
        public async Task<ActionResult<List<TramiteListaDTO>>> Get()
        {
            return _mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(await _tramitesService.GetTramites());
        }

        // GET api/<TramitesController>/5
        [HttpGet("{tramiteId:int}")]
        public async Task<ActionResult<TramiteDTO>> Get(int tramiteId)
        {
            return _mapper.Map<TramiteModel, TramiteDTO>(await _tramitesService.GetTramite(tramiteId));
        }

        // GET api/<TramitesController>/nuevos
        [HttpGet("{filtro}")]
        public async Task<ActionResult<List<TramiteDTO>>> Get(string filtro)
        {
            Console.Write(filtro);
            return _mapper.Map<List<TramiteModel>, List<TramiteDTO>>(await _tramitesService.GetTramitesByFilter(filtro));
        }

        // POST api/<TramitesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TramiteDTO tramite)
        {
            var resultado = await _tramitesService.Create(_mapper.Map<TramiteDTO, TramiteModel>(tramite));

            if (resultado > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<TramitesController>/5
        [HttpPut("{tramiteId}")]
        public void Put(int tramiteId, [FromBody] TramiteDTO tramite)
        {
            throw new Exception();
        }

        // DELETE api/<TramitesController>/5
        [HttpDelete("{tramiteId}")]
        public async Task<ActionResult> Delete(int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var tramite)
            {
                await _tramitesService.Delete(tramite);
                return NoContent();
            }

            return NotFound();
        }
    }
}