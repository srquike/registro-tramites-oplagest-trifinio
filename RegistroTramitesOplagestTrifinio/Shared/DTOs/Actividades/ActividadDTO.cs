namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Actividades
{
    public class ActividadDTO
    {
        public int ActividadId { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly? Hora { get; set; }
        public string? Resumen { get; set; }
        public string? NombreUsuario { get; set; }
        public string? UsuarioId { get; set; }
    }
}
