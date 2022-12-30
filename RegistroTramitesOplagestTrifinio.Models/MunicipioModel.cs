namespace RegistroTramitesOplagestTrifinio.Models
{
    public class MunicipioModel
    {
        public int MunicipioId { get; set; }
        public string? Nombre { get; set; }
        public int? DepartamentoId { get; set; }

        // Propiedades de navegación
        public virtual DepartamentoModel? Departamento { get; set; }
        public virtual ICollection<DireccionModel> Direcciones { get; } = new List<DireccionModel>();
    }
}
