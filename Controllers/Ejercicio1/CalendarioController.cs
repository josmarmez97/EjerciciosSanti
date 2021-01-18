using System;
using Microsoft.AspNetCore.Mvc;
using EJERCICIOS.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Collections.Generic;

namespace EJRCICIOS.Controllers
{
    public class CalendarioController : Controller
    {

        public IActionResult Index()
        {

            ViewData["Fecha"] = DateTime.Now.ToString("yyyy-MM-dd");

            return View();
        }
        public ActionResult Fechas()
        {
            return View();
        }

        // POST: CalendarioController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string fi = collection["FechaInicio"];
                string ff = collection["FechaFin"];
                int p = Convert.ToInt32(collection["Perio"]);
                int di = Convert.ToInt32(collection["DiaImp"]);
                int dc = Convert.ToInt32(collection["DiaCorte"]);

                List<Calendario> calendario = new List<Calendario>();
                calendario = generarFechas(fi, ff, p, di, dc);

                return View("Fechas", calendario);
            }


            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Calendario");
            }
        }

        public List<Calendario> generarFechas(string fi, string ff, int p, int di, int dc)
        {
            //Crear la lista donde se pondra cada fecha geerada para imprimir en view Fechas
            List<Calendario> calendario = new List<Calendario>();
            //parsear fecha inicio y fecha fin en DateTime
            var pfi = DateTime.Parse(fi);
            var pff = DateTime.Parse(ff);

            //calcular cuantas iteraciones se haran para imprimir fechas 
            var aniosAMesesDif = (pff.Year - pfi.Year) * 12;
            var mesesDiferencia = (pff.Month - (pfi.Month - 1));
            var mesesAIterar = aniosAMesesDif + mesesDiferencia;
            var iteracion = Math.Floor(Convert.ToDouble(mesesAIterar / p));


            //Variable utilizada como referencia y manipulacion
            var mesVariable = new DateTime(pfi.Year, pfi.Month, pfi.Day);
            var varMesVariable = new DateTime();


            var t = 1;
            for (var i = 1; i <= iteracion; i++)
            {
                var x = p * t;
                //suma los meses a iterar

                if (p == 1)
                {
                    if (i == 1)
                    {
                        varMesVariable = mesVariable;
                        t = 0;
                    }
                    else
                    {
                        varMesVariable = mesVariable.AddMonths(t);
                    }
                }
                else
                {
                    varMesVariable = mesVariable.AddMonths(x);
                }



                var diasDelMes = DateTime.DaysInMonth(varMesVariable.Year, varMesVariable.Month);

                DateTime fechaFinal;
                DateTime fechaIncialSiguiente;
                DateTime fechaDeImpresion;

                if (dc > diasDelMes)
                {
                    fechaFinal = new DateTime(varMesVariable.Year, varMesVariable.Month, diasDelMes);
                }
                else
                {
                    fechaFinal = new DateTime(varMesVariable.Year, varMesVariable.Month, dc);
                }
                if (i == 1)
                {
                    fechaIncialSiguiente = pfi;
                }
                else
                {
                    if (p == 1)
                    {
                        fechaIncialSiguiente = new DateTime(fechaFinal.Year, fechaFinal.Month, 1);
                    }

                    else
                    {
                        fechaIncialSiguiente = fechaFinal.AddDays(1);
                    }

                }

                if (di > diasDelMes)
                {
                    fechaDeImpresion = new DateTime(varMesVariable.Year, varMesVariable.Month, diasDelMes);
                }
                else
                {
                    fechaDeImpresion = new DateTime(varMesVariable.Year, varMesVariable.Month, di);
                }
                calendario.Add(
                    new Calendario
                    {
                        FechaInicio = fechaIncialSiguiente.ToString("d"),
                        FechaFin = fechaFinal.ToString("d"),
                        DiaImp = fechaDeImpresion.ToString("d")

                    }
                );
                t++;
            }

            return calendario;
        }

    }



}