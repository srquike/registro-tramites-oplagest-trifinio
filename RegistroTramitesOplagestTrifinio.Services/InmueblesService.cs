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

        public async Task<InmuebleModel> GetInmuebleAsync(int id)
        {
            return await _context.Inmuebles
                //.Include(i => i.Direccion)
                //.ThenInclude(d => d.Municipio)
                //.ThenInclude(m => m.Departamento)
                .Include(i => i.Propietario)
                //.ThenInclude(p => p.Direccion)
                //.ThenInclude(d => d.Municipio)
                //.ThenInclude(m => m.Departamento)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.InmuebleId == id);
        }

        public async Task<List<InmuebleModel>> GetInmueblesAsync()
        {
            return await _context.Inmuebles
                //.Include(i => i.Direccion)
                //.ThenInclude(d => d.Municipio)
                //.ThenInclude(m => m.Departamento)
                .Include(i => i.Propietario)
                .Include(i => i.Proyecto)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> CreateAsync(InmuebleModel inmueble)
        {
            await _context.AddAsync(inmueble);
            await _context.SaveChangesAsync();

            return inmueble.InmuebleId;
        }
    }
}
