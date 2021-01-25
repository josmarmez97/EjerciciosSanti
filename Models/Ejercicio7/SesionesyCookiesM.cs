using System;
using System.ComponentModel.DataAnnotations;

namespace EJERCICIOS.Models
{
    public class SesionesyCookiesM
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [Display(Name = "Usuario")]
        public string username { get; set; }

        [Required(ErrorMessage = "No olvide ingresar su contraseña")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}