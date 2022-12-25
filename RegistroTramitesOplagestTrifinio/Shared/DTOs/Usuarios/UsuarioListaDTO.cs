namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioListaDTO
    {
        public string? UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Rol { get; set; }
        public bool Activo { get; set; }
        public DateOnly? FechaCreacion { get; set; }
    }
}
