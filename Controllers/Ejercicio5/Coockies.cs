using System.Net;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using EJERCICIOS.Models;
using Microsoft.AspNetCore.Http;

namespace EJERCICIOS.Controllers
{
    public class Coockies : Controller
    {
        public IActionResult RegistroCoockies()
        {
            ViewData["Fecha"] = DateTime.Now.ToString("yyyy-MM-ddThh:mm");

            return View(ViewBag.x);
        }

        [HttpPost]
        public IActionResult CreateCoockie(IFormCollection collection)
        {


            DateTime fecha = DateTime.Parse(collection["Fecha"]);


            CookieOptions cookie2 = new CookieOptions();

            cookie2.Expires = fecha;

            Response.Cookies.Append("cookieM", collection["nombre"] + " " + collection["Correo"] + " " + collection["Fecha"], cookie2);


            var x = Request.Cookies["cookieM"];


            ViewData["coockie"] = collection["nombre"] + " " + collection["Correo"] + " " + collection["Fecha"];


            return View();
        }

        public IActionResult comprobar()
        {
            var x = Request.Cookies["cookieM"];


            if (Request.Cookies["cookieM"] != null)
            {
                ViewData["coockie"] = x;

                return View("CreateCoockie");
            }
            else
            {
                return RedirectToAction("RegistroCoockies");
            }

        }
    }
}