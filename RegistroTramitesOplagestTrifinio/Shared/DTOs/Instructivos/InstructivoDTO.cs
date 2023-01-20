using RegistroTramitesOplagestTrifinio.Shared.DTOs.Requisitos;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Instructivos
{
    public class InstructivoDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int? InstructivoId { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Nombre { get; set; }
    }
}