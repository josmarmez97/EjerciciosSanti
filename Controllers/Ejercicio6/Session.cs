using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EJERCICIOS.Models;
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

                HttpContext.Session.SetString("mySession", collection["Usuario"] + collection["Contrasenia"] + Convert.ToInt32(collection["Tiempo"]));

                return View();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Home")
            }
        }
    }
}