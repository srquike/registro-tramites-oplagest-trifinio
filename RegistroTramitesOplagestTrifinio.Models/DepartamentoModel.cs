namespace RegistroTramitesOplagestTrifinio.Models
{
    public class DepartamentoModel
    {
        public int DepartamentoId { get; set; }
        public string? Nombre { get; set; }
        public string? Iso { get; set; }
        public virtual ICollection<MunicipioModel> Municipios { get; } = new List<MunicipioModel>();
        public virtual ICollection<DireccionModel> Direcciones { get; } = new List<DireccionModel>();
    }
}