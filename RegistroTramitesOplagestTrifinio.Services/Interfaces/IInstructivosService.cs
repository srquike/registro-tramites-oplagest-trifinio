﻿using RegistroTramitesOplagestTrifinio.Models;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    public interface IInstructivosService
    {
        Task Create(InstructivoModel instructivo);
        Task Delete(int instructivoId);
        Task Update(InstructivoModel instructivo);
        Task<List<InstructivoModel>> GetInstructivos();
        Task<InstructivoModel> GetInstructivo(int instructivoId);
    }
}
