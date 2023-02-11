using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class MunicipioDTO
    {
        public int MunicipioId { get; set; }
        public string? Nombre { get; set; }

        //public DepartamentoDTO Departamento { get; set; } = new();
    }
}
