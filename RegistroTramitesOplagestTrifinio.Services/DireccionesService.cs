using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class DireccionesService : IDireccionesService
    {
        private readonly ApplicationDbContext _context;

        public DireccionesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> UpdateAsync(DireccionModel direccion)
        {
            _context.Direcciones.Entry(direccion).State = EntityState.Modified;

            var resultado = await _context.SaveChangesAsync();

            _context.Direcciones.Entry(direccion).State = EntityState.Detached;

            return resultado;
        }
    }
}
