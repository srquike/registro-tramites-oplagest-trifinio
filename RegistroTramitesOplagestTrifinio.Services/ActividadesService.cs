using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class ActividadesService : IActividadesService
    {
        private readonly ApplicationDbContext _context;

        public ActividadesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(ActividadModel model)
        {
            await _context.Actividades.AddAsync(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ActividadModel>> GetActividadesAsync()
        {
            return await _context.Actividades.AsNoTracking().ToListAsync();
        }

        public IQueryable<ActividadModel> GetActividadesQueryable()
        {
            return _context.Actividades.AsNoTracking();
        }
    }
}
