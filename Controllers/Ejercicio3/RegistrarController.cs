using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EJERCICIOS.Controllers
{
    public class RegistrarController : Controller
    {

        [HttpPost]
        public ActionResult NuevoRegistro(IFormCollection collection)
        {
            try
            {
                string id = collection["ID"];
                string nombre = collection["Nombre"];
                string pais = collection["Pais"];
                string comentario = collection["Comentario"];

                var exito = Registar(id, nombre, pais, comentario);

                if (exito == false)
                {

                    RedirectToAction("Index", "Home");

                }

                return RedirectToAction("index", "Visitas");

            }

            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Index");
            }

        }

        public bool Registar(string id, string nombre, string pais, string comentario)
        {
            var exito = false;

            string dataPath = @"D:\Trabajo\Capacitacion\C#\archivos\Libro de Visitas.txt";



            if (System.IO.File.Exists(dataPath))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.AppendText(dataPath))
                {
                    sw.WriteLine(Environment.NewLine + nombre + "," + pais + "," + comentario);
                }
            }

            return exito;
        }

    }
}
