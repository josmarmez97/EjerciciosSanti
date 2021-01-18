
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using EJERCICIOS.Models;

namespace EJERCICIOS.Controllers
{
    public class RegistroEventoController : Controller
    {
        [HttpPost]
        public IActionResult RegistroNuevo(IFormCollection collection)
        {
            try
            {
                string tiempoInicio = collection["TiempoInicio"];
                string tiempoFin = collection["TiempoFin"];

                string horario = tiempoInicio + "-" + tiempoFin;




                var exito = BFCoinciden(tiempoInicio, tiempoFin, collection["Fecha"]);

                if (exito == false)
                {
                    Registar(collection["Fecha"], horario, collection["Actividad"], collection["Nota"]);
                    return RedirectToAction("Agenda", "Agenda");
                }

                return RedirectToAction("RegistroNuevo", "Agenda");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Agenda", "Agenda");
            }
        }

        public void Registar(string fecha, string horario, string Actividad, string Nota)
        {

            string dataPath = @"D:\Trabajo\Capacitacion\C#\archivos\Agenda.txt";

            if (System.IO.File.Exists(dataPath))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.AppendText(dataPath))
                {
                    sw.WriteLine(fecha + "," + horario + "," + Actividad + "," + Nota);
                }
            }

        }

        public bool BFCoinciden(string tiempoInicio, string tiempoFin, string fecha)
        {
            var exito = false;
            var fechaP = fecha.Split("-");
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


            var tIp = tiempoInicio.Split(":");
            var tFp = tiempoFin.Split(":");


            // DateTime tiempoIP = new DateTime(Convert.ToInt32(fechaP[0]), Convert.ToInt32(fechaP[1]), Convert.ToInt32(fechaP[2]), Convert.ToInt32(tIp[0]), Convert.ToInt32(tIp[1]), 0);
            // DateTime tiempoFP = new DateTime(Convert.ToInt32(fechaP[0]), Convert.ToInt32(fechaP[1]), Convert.ToInt32(fechaP[2]), Convert.ToInt32(tFp[0]), Convert.ToInt32(tFp[1]), 0);

            List<Agenda> coincidencias = new List<Agenda>();

            coincidencias = agenda.FindAll(e => e.Fecha == fecha);

            if (coincidencias.Count == 0) { return exito; }

            for (var i = 0; i < coincidencias.Count; i++)
            {
                var p = coincidencias[i].Horario;//"13:00-14:00"
                var r = p.Split("-");//13:00 14:00
                var s = r[0].Split(":");//13 00
                var t = r[1].Split(":");//14 00
                var y = Convert.ToInt16(s[0]);//13 horas   iniciales de mi registro YA registrado
                var o = Convert.ToInt16(s[1]);//00 minutos iniciales de mi registro YA registrado

                var m = Convert.ToInt16(t[0]);//14  horas  finales de mi registro YA registrado
                var n = Convert.ToInt16(t[1]);//00 minutos finales   de mi registro YA registrado

                var z = Convert.ToInt16(tIp[0]);//  horas    iniciales de mi registroNuevo
                var k = Convert.ToInt16(tIp[1]);// minutos   iniciales de mi registro nuevo

                var l = Convert.ToInt16(tFp[0]);//la  hora    final   de mi registroNuevo
                var j = Convert.ToInt16(tFp[1]);//los minutos finales de mi registro nuevo

                if ((z < m && l > m))
                //horas iniciales del NR es MENOR a las horas finales del YR AND horas finales del NR es MAYOR a horas finales YR
                {
                    exito = true;
                }
                //horas finales del NR es MENOR a horas finales YR AND horas iniciales de NR MAYOR a horas iniciales del YR
                if ((l < m && z > y) && (l < m || z > y))
                {
                    exito = true;
                }
                if (z < y && l < m && l > y)
                {
                    exito = true;
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //minutos iniciales del NR MENOR a minutos finales del YR AND minutos finales de NR es MENOR a minutos inicales del YR
                if (k < n || j < o)
                {
                    exito = true;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////                
                if (z == m && z > y && l > m) { exito = false; }
                if (z < y && l < m && n > o)
                {
                    exito = true;
                }
            }
            return exito;

        }
    }
}