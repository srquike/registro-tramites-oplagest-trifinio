using RegistroTramitesOplagestTrifinio.Shared.DTOs.Requisitos;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Instructivos
{
    public class InstructivoDTO
    {
        [Required]
        public int? InstructivoId { get; set; }

        public string? Nombre { get; set; }
    }
}