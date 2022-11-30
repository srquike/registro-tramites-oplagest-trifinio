namespace RegistroTramitesOplagestTrifinio.Shared.DTOs
{
    public record UsuarioDTO
    {
        public string UsuarioId { get; init; } = string.Empty;
        public string Nombre { get; init; } = string.Empty;
        public string CorreoElectronico { get; init; } = string.Empty;
        public string Clave { get; init; } = string.Empty;
    }
}
