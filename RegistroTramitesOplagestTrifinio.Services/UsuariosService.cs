using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly ApplicationDbContext _context;

        public UsuariosService(OplagestDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(UsuarioModel usuario)
        {
            await _context.Usuarios.AddAsync(usuario);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string usuarioId)
        {
            var usuario = await GetUsuario(usuarioId);
            var resultado = 0;

            if (usuario != null)
            {
                _context.Remove(usuario);
                resultado = await _context.SaveChangesAsync();
            }

            return resultado;
        }

        public async Task<UsuarioModel> GetUsuario(string usuarioId)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == usuarioId);
        }

        public Task<List<IdentityUserRole<string>>> GetUsuarios()
        {
            throw new Exception();
        }

        public async Task<int> Update(UsuarioModel usuario)
        {
            _context.Usuarios.Update(usuario);
            return await _context.SaveChangesAsync();
        }
    }
}