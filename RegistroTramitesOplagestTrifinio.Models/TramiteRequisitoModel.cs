﻿namespace RegistroTramitesOplagestTrifinio.Models
{
    public class TramiteRequisitoModel
    {
        public int TramiteRequisitoId { get; set; }
        public bool Entregado { get; set; }
        public int? TramiteId { get; set; }
        public int? RequisitoId { get; set; }
        public TramiteModel? Tramite { get; set; }
        public RequisitoModel? Requisito { get; set; }
    }
}
