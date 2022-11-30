using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Data.Database
{
    public class MongoDbContext
    {
        public IMongoCollection<UsuarioModel>? _usuariosCollection;
        public IMongoCollection<InstructivoModel>? _instructivoCollection;

        public MongoDbContext(IConfiguration configuration)
        {
            var cliente = new MongoClient(configuration.GetConnectionString("MongoDBServer"));
            var database = cliente.GetDatabase("oplagest");

            InicializarColecciones(database);
        }

        private void InicializarColecciones(IMongoDatabase database)
        {
            _usuariosCollection = database.GetCollection<UsuarioModel>("usuarios");
            _instructivoCollection = database.GetCollection<InstructivoModel>("instructivos");
        }
    }
}