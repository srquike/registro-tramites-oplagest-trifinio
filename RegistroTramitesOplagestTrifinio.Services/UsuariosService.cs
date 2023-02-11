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

        public UsuariosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(UsuarioModel usuario)
        {
            await _context.AspNetUsers.AddAsync(usuario);

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
            return await _context.AspNetUsers
                .Include(u => u.UsuariosRoles)
                .ThenInclude(ur => ur.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == usuarioId);
        }

        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            return await _context.AspNetUsers
                .Include(u => u.UsuariosRoles)
                .ThenInclude(ur => ur.Role)
                .Where(u => u.Email != "root@asociaciontrifinio.org")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> Update(UsuarioModel usuario)
        {
            _context.AspNetUsers.Entry(usuario).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}