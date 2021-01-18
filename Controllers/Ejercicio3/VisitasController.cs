using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EJERCICIOS.Models;
using System.IO;
using System.Threading.Tasks;

namespace EJERCICIOS.Controllers
{
    public class VisitasController : Controller
    {
        public IActionResult Index()
        {

            List<Visitas> visitas = new List<Visitas>();

            visitas = leerArchivo();

            return View(visitas);
        }

        public IActionResult Registrar()
        {
            List<Visitas> comentarios = new List<Visitas>();


            comentarios = leerArchivo();

            var nuevoID = comentarios.Count;

            ViewData["nuevoID"] = nuevoID + 1;
            return View();
        }

        public ActionResult Editar(int? id)
        {

            List<Visitas> comentarios = new List<Visitas>();


            comentarios = leerArchivo();

            Visitas comEncontrado = comentarios.Find(x => x.ID == id);

            ViewData["Comentario"] = comEncontrado;

            return View();

        }

        public ActionResult Eliminar(int? id)
        {
            var x = Convert.ToInt32(id);
            string dataPath = @"D:\Trabajo\Capacitacion\C#\archivos\Libro de Visitas.txt";
            string[] readText = System.IO.File.ReadAllLines(dataPath);
            readText[x] = "";
            System.IO.File.WriteAllLines(dataPath, readText);
            return View();
        }

        public List<Visitas> leerArchivo()
        {
            string dataPath = @"D:\Trabajo\Capacitacion\C#\archivos\Libro de Visitas.txt";

            List<Visitas> visitas = new List<Visitas>();

            if (!System.IO.File.Exists(dataPath))
            {
                // Create a file to write to.
                string createText = "Nombre" + "," + "Pais" + "," + "Comentario";
                System.IO.File.WriteAllText(dataPath, createText);
            }


            string[] readText = System.IO.File.ReadAllLines(dataPath);


            for (var i = 1; i < readText.Length;)
            {
                if (readText[i] == "")
                { i++; }
                else
                {
                    var x = readText[i].Split(",");
                    visitas.Add(new Visitas
                    {
                        ID = i,
                        Nombre = x[0],
                        Pais = x[1],
                        Comentario = x[2]

                    });
                    i++;
                }

            }

            return visitas;
        }

    }
}
