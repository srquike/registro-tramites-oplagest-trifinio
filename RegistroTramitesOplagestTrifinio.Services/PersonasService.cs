using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class PersonasService : IPersonasService
    {
        private readonly ApplicationDbContext _context;

        public PersonasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> UpdateAsync(PersonaModel persona)
        {
            _context.Personas.Entry(persona).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }
    }
}
