using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class TramitesService : ITramitesService
    {
        private readonly ApplicationDbContext _context;

        public TramitesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(TramiteModel tramite)
        {
            await _context.AddAsync(tramite);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int tramiteId)
        {
            var resultado = 0;

            if (await GetTramite(tramiteId) is var tramite)
            {
                _context.Remove(tramite);
                resultado = await _context.SaveChangesAsync();
            }

            return resultado;
        }

        public async Task<TramiteModel> GetTramite(int tramiteId)
        {
            return await _context.Tramites.AsNoTracking().FirstOrDefaultAsync(t => t.TramiteId.Equals(tramiteId));
        }

        public async Task<List<TramiteModel>> GetTramites()
        {
            return await _context.Tramites.AsNoTracking().ToListAsync();
        }

        public async Task<int> Update(int tramiteId, TramiteModel tramite)
        {
            var resultado = 0;

            if (await GetTramite(tramiteId) is var busqueda)
            {
                _context.Tramites.Entry(busqueda).State = EntityState.Modified;
                resultado = await _context.SaveChangesAsync();
            }

            return resultado;
        }
    }
}