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
    }
}
