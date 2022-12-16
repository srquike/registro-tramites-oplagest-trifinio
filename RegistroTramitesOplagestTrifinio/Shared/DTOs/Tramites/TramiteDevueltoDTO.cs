using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class TramiteDevueltoDTO 
    {
        [Required(ErrorMessage = "Campo requerido.")] 
        public string? MotivoDevolucion { get; set; }

        [Required(ErrorMessage = "Campo requerido.")] 
        public string? ComentariosDevolucion { get; set; }
    }
}
