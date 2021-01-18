using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using EJERCICIOS.Models;

namespace EJERCICIOS.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Agenda()
        {
            var agenda = leerAgenda();

            return View(agenda);
        }

        private List<Agenda> leerAgenda()
        {
            List<Agenda> agenda = new List<Agenda>();
            var dataPath = @"D:\Trabajo\Capacitacion\C#\archivos\Agenda.txt";

            if (!System.IO.File.Exists(dataPath))
            {
                // Create a file to write to.
                string createText = "Fecha" + "," + "Horario" + "," + "Actividad" + "," + "Nota" + Environment.NewLine;
                System.IO.File.WriteAllText(dataPath, createText);
            }

            string[] readText = System.IO.File.ReadAllLines(dataPath);

            for (var i = 1; i < readText.Length; i++)
            {
                var x = readText[i].Split(",");
                agenda.Add(new Agenda
                {
                    ID = i,
                    Fecha = x[0],
                    Horario = x[1],
                    Actividad = x[2],
                    Nota = x[3],

                });
            }

            return agenda;
        }

        public IActionResult RegistroNuevo()
        {
            //ViewData["Fecha"] = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            ViewData["Fecha"] = DateTime.Now.ToString("yyyy-MM-dd");
            ViewData["Hora"] = DateTime.Now.ToString("hh:mm");

            return View();
        }
    }
}
