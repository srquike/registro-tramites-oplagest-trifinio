using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using RegistroTramitesOplagestTrifinio.Client.Pages.Tramites;
using RegistroTramitesOplagestTrifinio.Client.Shared.Tramites;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Visitas;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;

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
        private readonly IEmailService _emailService;

        public TramitesController(IMapper mapper, ITramitesService tramitesService, IVisitasService visitasService, IDevolucionesService devolucionesService, IEmailService emailService)
        {
            _mapper = mapper;
            _tramitesService = tramitesService;
            _visitasService = visitasService;
            _devolucionesService = devolucionesService;
            _emailService = emailService;
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

            return respuesta;
        }

        // GET api/<TramitesController>/nuevos
        [HttpGet("{filtro}")]
        public async Task<ActionResult<List<TramiteListaDTO>>> Get(string filtro)
        {
            var tramites = await _tramitesService.GetTramitesByEstado(filtro);

            return _mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(tramites);
        }

        // POST api/<TramitesController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] FormularioTramiteDTO dTO)
        {
            var tramite = _mapper.Map<FormularioTramiteDTO, TramiteModel>(dTO);
            tramite.Estado = "Nuevo";
            tramite.FechaEgreso = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(20));
            tramite.FechaIngreso = DateOnly.FromDateTime(DateTime.UtcNow);

            var tramiteId = await _tramitesService.Create(tramite);

            if (tramiteId <= 0)
            {
                return BadRequest();
            }

            return tramiteId;
        }

        [HttpPost("email")]
        public async Task EnviarCorreoElectronico([FromBody] int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var resultado)
            {
                var tramite = _mapper.Map<TramiteModel, TramiteDTO>(resultado);

                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Plataforma OPLAGEST-Trifinio", "plataforma@asociaciontrifinio.org"));
                message.Subject = "Trámite nuevo en recepción";
                message.To.AddRange(new List<MailboxAddress>
                {
                    new MailboxAddress("Enrique Coreas", "jonathan.vanegas@catolica.edu.sv"),
                    new MailboxAddress("Brayan Rivas", "brayan.rivas@catolica.edu.sv")
                });
                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = string.Format
                    (
                        $"<h1>Tr&aacute;mite nuevo en recepci&oacute;n</h1>" +
                        $"<p>Detalles del tr&aacute;mite:</p>" +
                        $"<ul>" +
                        $"<li>Receptor: {tramite.Receptor}</li>" +
                        $"<li>Expediente: {tramite.Expediente}</li>" +
                        $"<li>Instructivo: {tramite.Instructivo}</li>" +
                        $"</ul>" +
                        $"<p>Detalles del proyecto:</p>" +
                        $"<ul>" +
                        $"<li>Nombre del proyecto: {tramite.Proyecto}</li>" +
                        $"<li>Encargado del proyecto: {tramite.Encargado}</li>" +
                        $"<li>Tel&eacute;fono del encargado: {tramite.EncargadoTelefono}</li>" +
                        $"</ul>" +
                        $"<p>Detalles del inmueble:</p>" +
                        $"<ul>" +
                        $"<li>Propietario del inmueble: {tramite.Propietario}</li>" +
                        $"<li>Tel&eacute;fono del propietario: {tramite.PropietarioTelefono}</li>" +
                        $"<li>Direcci&oacute; del inmueble: {tramite.InmuebleDireccion}</li>" +
                        $"</ul>" 
                    )
                };

                await _emailService.Enviar(message);
            }
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

        [HttpPost("archivar")]
        public async Task<ActionResult> Archivar([FromBody] ArchivarDTO archivar)
        {
            if (await _tramitesService.GetTramite(archivar.TramiteId.Value) is var tramite)
            {
                tramite.Estado = archivar.Estado;
                tramite.ArchivadoDesde = archivar.ArchivadoDesde;

                if (await _tramitesService.Update(tramite) > 0)
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

        [HttpPost("desarchivar")]
        public async Task<ActionResult> Desarchivar([FromBody] ArchivarDTO archivar)
        {
            if (await _tramitesService.GetTramite(archivar.TramiteId.Value) is var tramite)
            {
                tramite.Estado = archivar.Estado;
                tramite.ArchivadoDesde = archivar.ArchivadoDesde;

                if (await _tramitesService.Update(tramite) > 0)
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

        [HttpGet("editar/{tramiteId:int}")]
        public async Task<ActionResult<FormularioTramiteDTO>> ObtenerParaEditar(int tramiteId)
        {
            return _mapper.Map<TramiteModel, FormularioTramiteDTO>(await _tramitesService.GetTramite(tramiteId));
        }

        [HttpPost("requisitos")]
        public async Task<ActionResult> CrearRequisitos([FromBody] List<TramiteRequisitoDTO> dTOs)
        {
            var requisitos = _mapper.Map<List<TramiteRequisitoDTO>, List<TramiteRequisitoModel>>(dTOs);

            if (await _tramitesService.CreateManyRequisitosAsync(requisitos) <= 0)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost("completarVisita")]
        public async Task<ActionResult> CompletarVisitaTecnica([FromBody] int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var tramite)
            {
                tramite.Estado = "Visitado";

                if (await _tramitesService.Update(tramite) > 0)
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

        [HttpPost("firmar")]
        public async Task<ActionResult> EnviarParaFirmar([FromBody] int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var tramite)
            {
                tramite.Estado = "Firmar";

                if (await _tramitesService.Update(tramite) > 0)
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

        [HttpPost("entregar")]
        public async Task<ActionResult> Entregar([FromBody] int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var tramite)
            {
                tramite.Estado = "Entregado";

                if (await _tramitesService.Update(tramite) > 0)
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

        [HttpPost("finalizar")]
        public async Task<ActionResult> Finalizar([FromBody] int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var tramite)
            {
                tramite.Estado = "Finalizado";

                if (await _tramitesService.Update(tramite) > 0)
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

        [HttpGet("devoluciones/{tramiteId:int}")]
        public async Task<ActionResult<List<DevolucionDTO>>> GetDevoluciones(int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is not null)
            {
                var devoluciones = await _devolucionesService.GetDevolucionesByTramiteIdAsync(tramiteId);

                return _mapper.Map<List<DevolucionModel>, List<DevolucionDTO>>(devoluciones);
            }

            return NotFound();
        }
    }
}