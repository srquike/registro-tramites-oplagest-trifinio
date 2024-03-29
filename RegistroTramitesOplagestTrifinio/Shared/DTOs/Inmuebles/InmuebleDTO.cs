﻿using RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Inmuebles
{
    public class InmuebleDTO
    {
        public int? InmuebleId { get; set; }
        public double? Area { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int? ProyectoId { get; set; }
        public int? PropietarioId { get; set; }
        public string? Direccion { get; set; }

        //public int? DireccionId { get; set; }
        //public DireccionDTO Direccion { get; set; } = new();

        public PersonaDTO Propietario { get; set; } = new();
    }
}
