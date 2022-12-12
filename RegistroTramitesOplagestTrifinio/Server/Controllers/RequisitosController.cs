using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Requisitos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RequisitosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRequisitosService _requisitosService;

        public RequisitosController(IMapper mapper, IRequisitosService requisitosService)
        {
            _mapper = mapper;
            _requisitosService = requisitosService;
        }

        // GET: api/<RequisitosController>
        [HttpGet]
        public async Task<ActionResult<List<RequisitoDTO>>> Get()
        {
            return _mapper.Map<List<RequisitoModel>, List<RequisitoDTO>>(await _requisitosService.GetRequisitos());
        }

        // GET api/<RequisitosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RequisitosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RequisitosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RequisitosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
