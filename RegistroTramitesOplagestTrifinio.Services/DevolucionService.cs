using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class DevolucionService : IDevolucionesService
    {
        private readonly ApplicationDbContext _context;

        public DevolucionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DevolucionModel devolucion)
        {
            _context.Devoluciones.Add(devolucion);
            return await _context.SaveChangesAsync();
        }
    }
}
