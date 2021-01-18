
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EJERCICIOS.Models;

namespace EJERCICIOS.Controllers
{
    public class TPascal : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TGenerado()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerarT(IFormCollection collection)
        {
            try
            {
                int n = Convert.ToInt32(collection["filas"]);


                List<TPascalVar> tpascalList = new List<TPascalVar>();

                tpascalList = genTtriangulo(n);

                //ViewData["tpascalList"] = tpascalList;
                return View("TGenerado", tpascalList);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Index");
            }



        }
        public List<TPascalVar> genTtriangulo(int n)
        {
            List<TPascalVar> tpascalArray = new List<TPascalVar>();

            for (int line = 1; line <= n; line++)
            {
                int c = 1;
                string tpascalList = "";
                for (int i = 1; i <= line; i++)
                {

                    tpascalList += c;
                    c = c * (line - i) / i;
                    tpascalList += " ";
                    tpascalList += " ";
                }

                tpascalArray.Add(new TPascalVar { filas = Convert.ToString(tpascalList) });
            }
            return tpascalArray;
        }

    }
}