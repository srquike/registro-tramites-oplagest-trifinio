using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Instructivos;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructivosController : ControllerBase
    {
        private readonly IInstructivosService _instructivosService;
        private readonly IMapper _mapper;

        public InstructivosController(IInstructivosService instructivosService, IMapper mapper)
        {
            _instructivosService = instructivosService;
            _mapper = mapper;
        }

        // GET: api/<InstructivosController>
        [HttpGet]
        public async Task<ActionResult<List<InstructivoDTO>>> Get()
        {
            return _mapper.Map<List<InstructivoModel>, List<InstructivoDTO>>(await _instructivosService.GetInstructivos());
        }
    }
}