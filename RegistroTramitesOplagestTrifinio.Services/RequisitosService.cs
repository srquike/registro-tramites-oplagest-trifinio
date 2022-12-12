using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class RequisitosService : IRequisitosService
    {
        private readonly ApplicationDbContext _context;

        public RequisitosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RequisitoModel>> GetRequisitos()
        {
            return await _context.Requisitos.AsNoTracking().ToListAsync();
        }
    }
}
