using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Data.Database;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Implementaciones;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructivosController : ControllerBase
    {
        private readonly MongoDBProvider<InstructivoModel> _provider;
        private readonly IInstructivosService _instructivosService;

        public InstructivosController()
        {
            _provider = new MongoDBProvider<InstructivoModel>("mongodb://localhost:27017", "oplagest");
            _instructivosService = new InstructivosService(_provider.GetMongoCollection("instructivos"));
        }

        // GET: api/<InstructivosController>
        [HttpGet]
        public async Task<List<InstructivoModel>> Get()
        {
            return await _instructivosService.GetInstructivos();
        }

        // GET api/<InstructivosController>/5
        [HttpGet("{instructivoId}")]
        public async Task<InstructivoModel> Get(string instructivoId)
        {
            return await _instructivosService.GetInstructivo(instructivoId);
        }

        // POST api/<InstructivosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InstructivoModel instructivo)
        {
            await _instructivosService.Create(instructivo);
            return Ok();
        }

        // PUT api/<InstructivosController>/5
        [HttpPut("{instructivoId}")]
        public async Task<ActionResult> Put(string instructivoId, [FromBody] InstructivoModel instructivo)
        {
            await _instructivosService.Update(instructivo);
            return Ok();
        }

        // DELETE api/<InstructivosController>/5
        [HttpDelete("{instructivoId}")]
        public async Task<ActionResult> Delete(string instructivoId)
        {
            await _instructivosService.Delete(instructivoId);
            return Ok();
        }
    }
}