﻿using RegistroTramitesOplagestTrifinio.Shared.DTOs.Requisitos;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Instructivos
{
    public class InstructivoDTO
    {
        public int InstructivoId { get; set; }
        public string? Nombre { get; set; }
        public ICollection<RequisitoDTO> Requisitos { get; set; } = new List<RequisitoDTO>();
    }
}