using System;
using System.ComponentModel.DataAnnotations;

namespace EJERCICIOS.Models
{

    public class Agenda
    {
        public int ID { get; set; }
        public string Fecha { get; set; }

        public string Horario { get; set; }

        public string Actividad { get; set; }

        public string Nota { get; set; }


    }
}