﻿using Microsoft.EntityFrameworkCore;
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
            await _context.SaveChangesAsync();

            return tramite.TramiteId;
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
                .Include(t => t.Inmueble)
                .ThenInclude(i => i.Proyecto)
                .ThenInclude(p => p.Encargado)
                .Include(t => t.Inmueble)
                .ThenInclude(i => i.Propietario)
                //.ThenInclude(i => i.Direccion)
                //.ThenInclude(d => d.Municipio)
                //.ThenInclude(m => m.Departamento)
                .Include(t => t.Inmueble)
                //.ThenInclude(i => i.Direccion)
                //.ThenInclude(d => d.Municipio)
                //.ThenInclude(m => m.Departamento)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TramiteId.Equals(tramiteId));
        }

        public async Task<List<TramiteModel>> GetTramites()
        {
            return await _context.Tramites
                .Include(t => t.Visitas)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<TramiteModel> GetTramitesByEstado(string filter)
        {
            return _context.Tramites
                .Include(t => t.Inmueble)
                .ThenInclude(i => i.Proyecto)
                .ThenInclude(p => p.Encargado)
                .Include(t => t.Inmueble)
                //.ThenInclude(i => i.Direccion)
                //.ThenInclude(d => d.Municipio)
                .Include(t => t.Visitas)
                .Where(t => t.Estado == filter)
                .AsNoTracking();
        }

        public async Task<int> Update(TramiteModel tramite)
        {
            _context.Tramites.Entry(tramite).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DepartamentoModel>> GetDepartamentosAsync()
        {
            return await _context.Departamentos
                .Where(d => d.Nombre == "Santa Ana")
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<List<MunicipioModel>> GetMunicipiosByDepartamentoAsync(int departamentoId)
        {
            return await _context.Municipios
                .Where(d => d.DepartamentoId == departamentoId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<TramiteRequisitoModel>> GetRequisitosByTramiteAsync(int tramiteId)
        {
            return await _context.TramitesRequisitos
                .Include(tr => tr.Requisito)
                .Where(x => x.TramiteId == tramiteId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ProyectoModel>> GetProyectosAsync()
        {
            return await _context.Proyectos
                .Include(p => p.Encargado)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> CreateProyectoAsync(ProyectoModel proyecto)
        {
            await _context.Proyectos.AddAsync(proyecto);
            await _context.SaveChangesAsync();

            return proyecto.ProyectoId;
        }

        public async Task<int> CreateManyRequisitosAsync(List<TramiteRequisitoModel> requisitos)
        {
            await _context.TramitesRequisitos.AddRangeAsync(requisitos);

            return await _context.SaveChangesAsync();
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

        public async Task<int> CreateInmuebleAsync(InmuebleModel inmueble)
        {
            await _context.Inmuebles.AddAsync(inmueble);
            await _context.SaveChangesAsync();

            return inmueble.InmuebleId;
        }

        public async Task<InmuebleModel> GetInmuebleAsync(int inmuebleId)
        {
            return await _context.Inmuebles
                //.Include(i => i.Direccion)
                //.ThenInclude(d => d.Municipio)
                //.ThenInclude(m => m.Departamento)
                .Include(i => i.Propietario)
                //.ThenInclude(p => p.Direccion)
                //.ThenInclude(d => d.Municipio)
                //.ThenInclude(m => m.Departamento)
                .Where(i => i.InmuebleId == inmuebleId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<int> UpdateInmuebleAsync(InmuebleModel inmueble)
        {
            _context.Update(inmueble);
            //var entry = _context.Inmuebles.Entry(inmueble);

            //entry.State = EntityState.Modified;
            //entry.Reference(e => e.Direccion).EntityEntry.State = EntityState.Modified;
            //entry.Reference(e => e.Propietario).EntityEntry.State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }
    }
}