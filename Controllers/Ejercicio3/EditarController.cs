using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EJERCICIOS.Models;

namespace EJERCICIOS.Controllers
{

    public class EditarController : Controller
    {

        [HttpPost]
        public IActionResult ComEditado(IFormCollection c)
        {
            try
            {
                string dataPath = @"D:\Trabajo\Capacitacion\C#\archivos\Libro de Visitas.txt";

                int id = Convert.ToInt32(c["ID"]);
                string datosNuevos = c["Nombre"] + "," + c["Pais"] + "," + c["comentario"];

                string[] readText = System.IO.File.ReadAllLines(dataPath);
                readText[id] = datosNuevos;
                System.IO.File.WriteAllLines(dataPath, readText);

                return RedirectToAction("Index", "Visitas");
            }
            catch (System.Exception ex)
            {
                // TODO
                Console.WriteLine(ex.Message);
                return View();
            }

        }




    }
}