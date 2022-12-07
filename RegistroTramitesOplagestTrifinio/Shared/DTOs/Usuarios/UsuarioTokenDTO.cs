namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioTokenDTO
    {
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
