using System;
using System.ComponentModel.DataAnnotations;

namespace EJERCICIOS.Models
{

    public class Calendario
    {
        [Required]
        public string FechaInicio { get; set; }

        [Required]
        public string FechaFin { get; set; }

        [Required]
        public string DiaImp { get; set; }


    }
}