using Microsoft.EntityFrameworkCore;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class TramitesService : ITramitesService
    {
        private readonly ApplicationDbContext _context;

        public TramitesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(TramiteModel tramite)
        {
            await _context.AddAsync(tramite);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(TramiteModel tramite)
        {
            _context.Remove(tramite);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Find(int tramiteId)
        {
            return await _context.Tramites.Where(t => t.TramiteId == tramiteId).CountAsync();
        }

        public async Task<TramiteModel> GetTramite(int tramiteId)
        {
            return await _context.Tramites
                .Include(t => t.Instructivo)
                .Include(t => t.Visitas)
                .Include(t => t.TramitesRequisitos)
                .ThenInclude(tr => tr.Requisito)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TramiteId.Equals(tramiteId));
        }

        public async Task<List<TramiteModel>> GetTramites()
        {
            return await _context.Tramites
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<TramiteModel>> GetTramitesByEstado(string filter)
        {
            return await _context.Tramites
                .AsNoTracking()
                .Where(t => t.Estado == filter)
                .ToListAsync();
        }

        public async Task<int> Update(TramiteModel tramite)
        {
            _context.Tramites.Update(tramite);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DepartamentoModel>> GetDepartamentosAsync()
        {
            return await _context.Departamentos.AsNoTracking().ToListAsync();
        }
    }
}