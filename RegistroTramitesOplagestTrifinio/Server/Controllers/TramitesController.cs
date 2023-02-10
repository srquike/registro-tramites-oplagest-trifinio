using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Server.Extensiones;
using RegistroTramitesOplagestTrifinio.Server.Herramientas;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Visitas;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador, Receptor, Técnico")]
    public class TramitesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITramitesService _tramitesService;
        private readonly IVisitasService _visitasService;
        private readonly IDevolucionesService _devolucionesService;
        private readonly IEmailService _emailService;
        private readonly ITramitesRequisitosService _tramitesRequisitosService;
        private readonly IAlertas _alertas;

        public TramitesController(IMapper mapper, ITramitesService tramitesService, IVisitasService visitasService, IDevolucionesService devolucionesService, IEmailService emailService, ITramitesRequisitosService tramitesRequisitosService, IAlertas alertas = null)
        {
            _mapper = mapper;
            _tramitesService = tramitesService;
            _visitasService = visitasService;
            _devolucionesService = devolucionesService;
            _emailService = emailService;
            _tramitesRequisitosService = tramitesRequisitosService;
            _alertas = alertas;
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
        public async Task<ActionResult<List<TramiteListaDTO>>> Get([FromQuery] PaginacionDTO paginacion, string filtro)
        {
            var queryable = _tramitesService.GetTramitesByEstado(filtro);
            var tramites = await queryable.OrderBy(t => t.Expediente).Paginar(paginacion).ToListAsync();

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.Cantidad);

            return _mapper.Map<List<TramiteModel>, List<TramiteListaDTO>>(tramites);
        }

        // GET api/<TramitesController>/nuevos
        [HttpGet("resumen")]
        public async Task<ActionResult<List<TramiteListaDTO>>> ObtenerTramites()
        {
            var tramites = await _tramitesService.GetTramites();

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
        public async Task EnviarCorreoElectronicoRecepcionado([FromBody] int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var resultado)
            {
                var to = new List<MailboxAddress> { new MailboxAddress("OPLAGEST-Trifinio", "trifinio.oplagest@gmail.com") };
                await EnviarCorreoElectronico("Trámite nuevo en recepción", string.Empty, resultado, to);
            }
        }

        [HttpPost("devueltos/email")]
        public async Task EnviarCorreoElectronicoDevuelto([FromBody] int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var resultado)
            {
                if ((await _devolucionesService.GetDevolucionesByTramiteIdAsync(resultado.TramiteId)).FirstOrDefault() is var devolucion)
                {
                    var to = new List<MailboxAddress> { 
                        new MailboxAddress("Ventanilla OPLAGEST", "ventanilla.oplagest@gmail.com"),
                        new MailboxAddress("OPLAGEST-Trifinio", "trifinio.oplagest@gmail.com")
                    };
                    var detalles = $"" +
                    $"<p>Detalles de la devolución:</p>" +
                    $"<ul>" +
                    $"<li>Motivo: {devolucion.Motivo}</li>" +
                    $"<li>Fecha: {devolucion.Fecha}</li>" +
                    $"<li>Etapa: {devolucion.Etapa}</li>" +
                    $"<li>Comentarios: {devolucion.Motivo}</li>" +
                    $"</ul>";

                    await EnviarCorreoElectronico("Trámite devuelto", detalles, resultado, to);
                }
            }
        }

        private async Task EnviarCorreoElectronico(string asunto, string contenido, TramiteModel resultado, List<MailboxAddress> to)
        {
            var tramite = _mapper.Map<TramiteModel, TramiteDTO>(resultado);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Plataforma OPLAGEST-Trifinio", "plataforma@asociaciontrifinio.org"));
            message.Subject = asunto;
            message.To.AddRange(to);
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = string.Format
                (
                    "<html>" +
                    $"<h1>{asunto}</h1>" +
                    $"{contenido}" +
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
                    $"<li>Direcci&oacute;n del inmueble: {tramite.InmuebleDireccion}</li>" +
                    $"</ul>" +
                    "</html>"
                )
            };

            await _emailService.Enviar(message);
        }

        [HttpPost("devueltos/corregir")]
        public async Task<IActionResult> CorregirDevuelto([FromBody] TramiteDTO dTO)
        {
            if (await _tramitesService.GetTramite(dTO.TramiteId.Value) is var resultado)
            {
                if ((await _devolucionesService.GetDevolucionesByTramiteIdAsync(resultado.TramiteId)).FirstOrDefault() is var devolucion)
                {
                    var to = new List<MailboxAddress> { new MailboxAddress("OPLAGEST-Trifinio", "trifinio.oplagest@gmail.com") };
                    var detalles = $"" +
                    $"<p>Detalles de la devolución:</p>" +
                    $"<ul>" +
                    $"<li>Motivo: {devolucion.Motivo}</li>" +
                    $"<li>Fecha: {devolucion.Fecha}</li>" +
                    $"<li>Comentarios: {devolucion.Motivo}</li>" +
                    $"</ul>";

                    await EnviarCorreoElectronico("Trámite devuelto corregido", detalles, resultado, to);

                    return NoContent();
                }
            }

            return NotFound();
        }

        [HttpPost("devueltos/continuar")]
        public async Task<IActionResult> ContinuarProceso([FromBody] int tramiteId)
        {
            if (await _tramitesService.GetTramite(tramiteId) is var tramite)
            {
                if ((await _devolucionesService.GetDevolucionesByTramiteIdAsync(tramite.TramiteId)).OrderByDescending(d => d.Fecha).FirstOrDefault() is var devolucion)
                {
                    tramite.Estado = devolucion.Etapa switch
                    {
                        "Para visitar" => "Agendado",
                        "Para entregar" => "Entregado",
                        "Finalizados" => "Finalizado",
                        "Para firmar" => "Firmar",
                        "Nuevos" => "Nuevo",
                        "Visitados" => "Visitado",
                        _ => "Devuelto"
                    };

                    tramite.FechaEgreso = ObtenerFechaEgreso(devolucion.Fecha, tramite.FechaEgreso.Value);

                    if (await _tramitesService.Update(tramite) > 0)
                    {
                        return NoContent();
                    }

                    return BadRequest();
                }
            }

            return NotFound();
        }

        private static DateOnly ObtenerFechaEgreso(DateOnly fechaDevolucion, DateOnly fechaEgreso)
        {
            var dias = 0;
            var limite = DateOnly.FromDateTime(DateTime.Today).DayNumber - fechaDevolucion.DayNumber;

            fechaEgreso.AddDays(1);

            while (dias != limite)
            {
                if (fechaEgreso.DayOfWeek != DayOfWeek.Saturday && fechaEgreso.DayOfWeek != DayOfWeek.Sunday)
                {
                    dias++;
                }

                fechaEgreso = fechaEgreso.AddDays(1);
            }

            return fechaEgreso.AddDays(-1);
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

        [HttpPut("requisitos/editar")]
        public async Task<ActionResult> EditarRequisitos([FromBody] List<TramiteRequisitoDTO> dTOs)
        {
            var requisitos = _mapper.Map<List<TramiteRequisitoDTO>, List<TramiteRequisitoModel>>(dTOs);

            if (await _tramitesRequisitosService.UpdateManyAsync(requisitos) > 0)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("editar")]
        public async Task<ActionResult> EditarTramite([FromBody] FormularioTramiteDTO dTO)
        {
            var resultado = _mapper.Map<FormularioTramiteDTO, TramiteModel>(dTO);

            if (await _tramitesService.GetTramite(resultado.TramiteId) is not null)
            {
                if (await _tramitesService.Update(resultado) is not 0)
                {
                    return NoContent();
                }

                return BadRequest();
            }

            return NotFound();
        }

        [HttpGet("alertas")]
        public async Task<ActionResult<AlertasDTO>> ObtenerAlertas()
        {
            return await _alertas.ObtenerAlertas();
        }        
        
        private int ObtenerDiferenciaDeFechasAntesDespues(DateOnly fecha)
        {
            var dias = DateOnly.FromDateTime(DateTime.Today).DayNumber - fecha.DayNumber;

            return dias;
        }
    }
}