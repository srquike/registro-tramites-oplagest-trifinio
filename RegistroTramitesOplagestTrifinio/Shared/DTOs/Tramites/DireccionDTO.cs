﻿using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class DireccionDTO
    {
        public int DireccionId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? Departamento { get; set; }
        
        [Required(ErrorMessage = "Campo requerido")]
        public string? Municipio { get; set; }


        //[Range(1, int.MaxValue)]
        //public int MunicipioId { get; set; }

        //public MunicipioDTO Municipio { get; set; } = new();
    }
}