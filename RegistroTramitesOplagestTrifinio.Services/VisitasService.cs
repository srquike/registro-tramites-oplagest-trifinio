using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class VisitasService : IVisitasService
    {
        private readonly ApplicationDbContext _context;

        public VisitasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(VisitaModel visita)
        {
            _context.Visitas.Add(visita);
            return await _context.SaveChangesAsync();
        }

        public async Task<VisitaModel> GetVisitaAsync(int id)
        {
            return await _context.Visitas
                .Include(v => v.Tramite)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.VisitaId == id);
        }
        
        public IQueryable<VisitaModel> GetVisitasAsync()
        {
            return _context.Visitas
                .Include(v => v.Tramite)
                .AsNoTracking();
        }

        public async Task<int> UpdateAsync(VisitaModel visita)
        {
            _context.Visitas.Entry(visita).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
