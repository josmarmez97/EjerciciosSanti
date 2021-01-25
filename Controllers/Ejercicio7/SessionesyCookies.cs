
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EJERCICIOS.Controllers
{
    public class SessionesyCookiesController : Controller
    {

        static string username;
        static string password;

        static string politica = "true";
        static string sport = "true";
        static string cultura = "true";

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Index()
        {

            //ViewData["preferencias"] = Request.Cookies[username];

            if (Request.Cookies[username + "A"] != null)
            {
                sport = "true";
            }
            else
            {
                sport = "false";
            }
            if (Request.Cookies[username + "B"] != null)
            {
                cultura = "true";
            }
            else
            {
                cultura = "false";
            }
            if (Request.Cookies[username + "C"] != null)
            {
                politica = "true";
            }
            else
            {
                politica = "false";
            }


            ViewData["politics"] = politica;
            ViewData["sports"] = sport;
            ViewData["cultural"] = cultura;

            return View();
        }

        public IActionResult Ingresar()
        {
            //Recibimos variables del formulario
            username = Request.Form["username"];
            password = Request.Form["password"];

            if (username != null && username != "")
            {
                HttpContext.Session.SetString("miSesion", username);

                if (Request.Cookies[username + "A"] == null && Request.Cookies[username + "B"] == null && Request.Cookies[username + "C"] == null)
                {
                    Response.Cookies.Append(username + "A", "deportes");
                    Response.Cookies.Append(username + "B", "cultura");
                    Response.Cookies.Append(username + "C", "politica");
                }


                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult LogOut()
        {

            HttpContext.Session.Remove(username);

            return RedirectToAction("Login");
        }

        public IActionResult Settings()
        {


            ViewData["politics"] = politica;
            ViewData["sports"] = sport;
            ViewData["cultural"] = cultura;


            return View();
        }

        public IActionResult NuevaConfig()
        {

            politica = Request.Form["politics"];
            sport = Request.Form["sports"];
            cultura = Request.Form["cultural"];
            if (sport == null)
            {
                sport = "false";
                Response.Cookies.Delete(username + "A");
            }
            else
            {
                Response.Cookies.Append(username + "A", "deportes");
            }
            if (cultura == null)
            {
                cultura = "false";
                Response.Cookies.Delete(username + "B");
            }
            else
            {
                Response.Cookies.Append(username + "B", "cultura");
            }
            if (politica == null)
            {
                politica = "false";
                Response.Cookies.Delete(username + "C");
            }
            else
            {
                Response.Cookies.Append(username + "C", "politica");
            }


            return RedirectToAction("Index");
        }



    }
}