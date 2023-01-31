using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class InmueblesService : IInmueblesService
    {
        private readonly ApplicationDbContext _context;

        public InmueblesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> UpdateAsync(InmuebleModel inmueble)
        {
            _context.Inmuebles.Entry(inmueble).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }
    }
}
