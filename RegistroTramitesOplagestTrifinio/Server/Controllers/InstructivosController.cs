using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructivosController : ControllerBase
    {
        private readonly IInstructivosService _instructivosService;

        public InstructivosController(IInstructivosService instructivosService)
        {
            _instructivosService = instructivosService;
        }

        // GET: api/<InstructivosController>
        [HttpGet]
        public async Task<ActionResult<List<InstructivoModel>>> Get()
        {
            return await _instructivosService.GetInstructivos();
        }
    }
}