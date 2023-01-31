namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Inmuebles
{
    public class InmuebleListadoDTO
    {
        public int InmuebleId { get; set; }
        public double Area { get; set; }
        public string? Propietario { get; set; }
        public string? Direccion { get; set; }
        public string? Proyecto { get; set; }
    }
}
