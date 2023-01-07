using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Proyectos;
using System.Data;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
    public class ProyectosController : ControllerBase
    {
        private readonly ITramitesService _tramitesService;
        private readonly IMapper _mapper;

        public ProyectosController(ITramitesService tramitesService, IMapper mapper)
        {
            _tramitesService = tramitesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProyectoDTO>>> GetProyectos()
        {
            return _mapper.Map<List<ProyectoModel>, List<ProyectoDTO>>(await _tramitesService.GetProyectosAsync());
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateProyecto([FromBody] ProyectoDTO dTO)
        {
            var proyecto = _mapper.Map<ProyectoDTO, ProyectoModel>(dTO);
            var proyectoId = await _tramitesService.CreateProyectoAsync(proyecto);

            if (proyectoId <= 0)
            {
                return BadRequest();
            }

            return proyectoId;
        }
    }
}