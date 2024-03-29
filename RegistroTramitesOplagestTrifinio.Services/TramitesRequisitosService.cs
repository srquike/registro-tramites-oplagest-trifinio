﻿using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services
{
    public class TramitesRequisitosService : ITramitesRequisitosService
    {
        private readonly ApplicationDbContext _context;

        public TramitesRequisitosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> UpdateManyAsync(List<TramiteRequisitoModel> requisitos)
        {
            _context.TramitesRequisitos.UpdateRange(requisitos);
            return await _context.SaveChangesAsync();
        }
    }
}
