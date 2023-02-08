using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs
{
    public class AlertaDTO
    {
        public List<TramiteListaDTO>? TramitesPorAgendar {get;set;}
        public List<TramiteListaDTO>? TramitesSinAgendar {get;set;}
        public List<TramiteListaDTO>? TramitesPorVisitar {get;set;}
        public List<TramiteListaDTO>? TramitesSinVisitar {get;set;}
        public List<TramiteListaDTO>? TramitesPorFirmar {get;set;}
        public List<TramiteListaDTO>? TramitesSinFirmar {get;set;}
    }
}
