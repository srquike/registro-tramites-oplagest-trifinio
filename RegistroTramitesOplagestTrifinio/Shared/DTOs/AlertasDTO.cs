using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs
{
    public class AlertasDTO
    {
        public List<TramiteListaDTO> TramitesPorAgendar {get;set;} = new();
        public List<TramiteListaDTO> TramitesSinAgendar {get;set;} = new();
        public List<TramiteListaDTO> TramitesPorVisitar {get;set;} = new();
        public List<TramiteListaDTO> TramitesSinVisitar {get;set;} = new();
        public List<TramiteListaDTO> TramitesPorFirmar {get;set;}  = new();
        public List<TramiteListaDTO> TramitesSinFirmar { get; set; } = new();
    }
}
