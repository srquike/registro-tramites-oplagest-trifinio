namespace RegistroTramitesOplagestTrifinio.Models
{
    public class MunicipioModel
    {
        public int MunicipioId { get; set; }
        public string? Nombre { get; set; }
        public int? DepartamentoId { get; set; }
        public virtual DepartamentoModel? Departamento { get; set; }
    }
}
