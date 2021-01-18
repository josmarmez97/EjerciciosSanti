using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EJERCICIOS.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult RegistroS()
        {
            return View();
        }

        public IActionResult Sessiones(IFormCollection collection)
        {
            try
            {
                HttpContext.Session.SetString("miSesion", collection["Usuario"] + " " + collection["Contrasenia"] + " " + Convert.ToString(collection["Tiempo"]) + " ");


                if (HttpContext.Session.Get("miSesion") != null)
                {

                    ViewData["Usuario"] = collection["Usuario"];

                    ViewData["Tiempo"] = Convert.ToInt32(collection["Tiempo"]);
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}