using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class InstructivosService : IInstructivosService
    {
        private readonly ApplicationDbContext _context;

        public InstructivosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InstructivoModel>> GetInstructivos()
        {
            return await _context.Instructivos
                .Include(i => i.Requisitos)
                .ThenInclude(r => r.Categoria)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}