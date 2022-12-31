using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Visitas;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
    public class TramitesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITramitesService _tramitesService;
        private readonly IVisitasService _visitasService;
        private readonly IDevolucionesService _devolucionesService;

        public TramitesController(IMapper mapper, ITramitesService tramitesService, IVisitasService visitasService, IDevolucionesService devolucionesService)
        {
            _mapper = mapper;
            _tramitesService = tramitesService;
            _visitasService = visitasService;
            _devolucionesService = devolucionesService;
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
            var tramite = await _tramitesService.GetTramite(tramiteId);
            var respuesta = _mapper.Map<TramiteModel, TramiteDTO>(tramite);

            respuesta.Direccion = $"{tramite.Direccion.Direccion}, {tramite.Direccion.Municipio.Nombre}, {tramite.Direccion.Municipio.Departamento.Nombre}";

            return respuesta;
        }

        // GET api/<TramitesController>/nuevos
        [HttpGet("{filtro}")]
        public async Task<ActionResult<List<FormularioTramiteDTO>>> Get(string filtro)
        {
            Console.Write(filtro);
            return _mapper.Map<List<TramiteModel>, List<FormularioTramiteDTO>>(await _tramitesService.GetTramitesByEstado(filtro));
        }

        // POST api/<TramitesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FormularioTramiteDTO tramite)
        {
            var resultado = await _tramitesService.Create(_mapper.Map<FormularioTramiteDTO, TramiteModel>(tramite));

            if (resultado > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<TramitesController>/5
        [HttpPut("{tramiteId}")]
        public async Task<ActionResult> Put(int tramiteId, [FromBody] FormularioTramiteDTO tramiteDTO)
        {
            if (await _tramitesService.Find(tramiteId) > 0)
            {
                var tramite = _mapper.Map<FormularioTramiteDTO, TramiteModel>(tramiteDTO);

                if (await _tramitesService.Update(tramite) > 0)
                {
                    return NoContent();
                }

                return BadRequest("No fue posible actualizar el trámite");
            }

            return NotFound("El trámite no fue encontrado");
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

        // POST api/tramites/agendar
        [HttpPost("agendar")]
        public async Task<ActionResult> Agendar([FromBody] VisitaDTO visita)
        {
            if (await _tramitesService.GetTramite((int)visita.TramiteId) is var tramite)
            {
                tramite.Estado = "Agendado";

                if (await _tramitesService.Update(tramite) > 0 && await _visitasService.Create(_mapper.Map<VisitaDTO, VisitaModel>(visita)) > 0)
                {
                    return NoContent();
                }

                return BadRequest();
            }

            return NotFound();
        }

        [HttpPost("devolver")]
        public async Task<ActionResult> Devolver([FromBody] DevolucionDTO devolucion)
        {
            if (await _tramitesService.GetTramite((int)devolucion.TramiteId) is var tramite)
            {
                tramite.Estado = "Devuelto";

                if (await _tramitesService.Update(tramite) > 0 && await _devolucionesService.Create(_mapper.Map<DevolucionDTO, DevolucionModel>(devolucion)) > 0)
                {
                    return NoContent();
                }

                return BadRequest();
            }

            return NotFound();
        }

        // PUT api/tramites/agendar
        [HttpPut("archivar")]
        public async Task<ActionResult> Archivar([FromBody] TramiteListaDTO tramite)
        {
            var resultado = await _tramitesService.GetTramite(tramite.TramiteId);

            if (resultado != null)
            {
                if (await _tramitesService.Update(_mapper.Map<TramiteListaDTO, TramiteModel>(tramite)) > 0)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }

            return NotFound();
        }

        [HttpGet("departamentos")]
        public async Task<ActionResult<List<DepartamentoDTO>>> GetDepartamentos()
        {
            return _mapper.Map<List<DepartamentoModel>, List<DepartamentoDTO>>(await _tramitesService.GetDepartamentosAsync());
        }
        
        [HttpGet("municipios/{departamentoId:int}")]
        public async Task<ActionResult<List<MunicipioDTO>>> GetDepartamentos(int departamentoId)
        {
            return _mapper.Map<List<MunicipioModel>, List<MunicipioDTO>>(await _tramitesService.GetMunicipiosByDepartamentoAsync(departamentoId));
        }

        [HttpGet("requisitos/{tramiteId:int}")]
        public async Task<ActionResult<List<TramiteRequisitoDTO>>> ObtenerRequisitos(int tramiteId)
        {
            return _mapper.Map<List<TramiteRequisitoModel>, List<TramiteRequisitoDTO>>(await _tramitesService.GetRequisitosByTramiteAsync(tramiteId));
        }
    }
}