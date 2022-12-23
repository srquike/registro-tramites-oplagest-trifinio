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
            return await _context.Visitas.AsNoTracking().FirstOrDefaultAsync(v => v.VisitaId == id);
        }

        public async Task<int> UpdateAsync(VisitaModel visita)
        {
            _context.Visitas.Update(visita);
            return await _context.SaveChangesAsync();
        }
    }
}
