using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs
{
    public record UsuarioDTO
    {
        public string UsuarioId { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico del usuario es obligatoria")]
        public string CorreoElectronico { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave del usuario es obligatoria")]
        public string Clave { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public DateTime? FechaCreacion { get; set; } = DateTime.Today;
    }
}