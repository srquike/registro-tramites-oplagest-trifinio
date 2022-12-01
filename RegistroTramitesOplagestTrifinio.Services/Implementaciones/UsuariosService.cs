using MongoDB.Driver;
using RegistroTramitesOplagestTrifinio.Data.Database;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services.Implementaciones
{
    public class UsuariosService : IUsuariosService
    {
        private readonly MongoDbContext _context;

        public UsuariosService(MongoDbContext context)
        {
            _context = context;
        }

        public Task Create(UsuarioModel usuario)
        {
            return _context._usuariosCollection!.InsertOneAsync(usuario);
        }

        public Task Delete(string usuarioId)
        {
            return _context._usuariosCollection.DeleteOneAsync(u => u.UsuarioId == usuarioId);
        }

        public Task<UsuarioModel> GetUsuario(string usuarioId)
        {
            return _context._usuariosCollection.FindAsync(u => u.UsuarioId == usuarioId).Result.FirstOrDefaultAsync();
        }

        public Task<List<UsuarioModel>> GetUsuarios()
        {
            return _context._usuariosCollection.FindAsync(u => true).Result.ToListAsync();
        }

        public Task Update(UsuarioModel usuario)
        {
            return _context._usuariosCollection.ReplaceOneAsync(u => u.UsuarioId == usuario.UsuarioId, usuario);
        }
    }
}