using System;
using System.ComponentModel.DataAnnotations;

namespace EJERCICIOS.Models
{
    public class Visitas
    {
        [Required]
        public int ID { get; set; }

        public string Nombre { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public string Comentario { get; set; }
    }
}