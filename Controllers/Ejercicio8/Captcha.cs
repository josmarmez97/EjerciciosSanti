using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using BotDetect.Web.Mvc;
using EJERCICIOS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EJERCICIOS.Controllers
{
    public class CaptchaController : Controller
    {


        private static Random random = new Random();
        static string captchaText;
        private int width = 500;
        private int height = 120;
        private Random rnd = new Random();


        public IActionResult VerCaptcha()
        {

            return View();
        }


        /*
                [HttpPost]
                [CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Wrong Captcha!")]
                public ActionResult ExampleAction(CapchaM capchaM)
                {
                    if (!ModelState.IsValid)
                    {
                        // TODO: Captcha validation failed, show error message
                        return View("VerCaptcha");

                    }
                    else
                    {
                        // TODO: captcha validation succeeded; execute the protected action  

                        // Reset the captcha if your app's workflow continues with the same view
                        MvcCaptcha.ResetCaptcha("ExampleCaptcha");

                        return View("Bienvenido");
                    }

                }
        */



        [HttpPost]
        public IActionResult CrearCaptcha(IFormCollection c)
        {
            string rs = RandomString();
            //Recibimos valores del formulario
            string opcion = Convert.ToString(c["Opciones"]);
            //Ejecutamos la generación de Captcha requerida

            if (opcion == "2")
            {
                rs = RandomString(1);
            }
            if (opcion == "1")
            {
                rs = RandomString(2);
            }
            if (opcion == "0")
            {
                rs = RandomString(0);
            }
            ViewBag.captchaText = rs;
            string source = generateCaptchaImage(rs);
            ViewBag.src = source;
            return View();
        }

        //Genera la imagen de un captcha con el String solicitado
        private string generateCaptchaImage(string encodedText)
        {
            //First declare a bitmap and declare graphic from this bitmap
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            //And create a rectangle to delegete this image graphic 
            Rectangle rect = new Rectangle(0, 0, width, height);
            //And create a brush to make some drawings
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.DottedGrid, Color.Aqua, Color.White);
            g.FillRectangle(hatchBrush, rect);
            //here we make the text configurations
            GraphicsPath graphicPath = new GraphicsPath();
            //add this string to image with the rectangle delegate
            graphicPath.AddString(encodedText, FontFamily.GenericMonospace, (int)FontStyle.Italic, 90, rect, null);
            //And the brush that you will write the text
            hatchBrush = new HatchBrush(HatchStyle.Percent20, Color.Green, Color.Yellow);
            g.FillPath(hatchBrush, graphicPath);
            //We are adding the dots to the image
            for (int i = 0; i < (int)(rect.Width * rect.Height / 50F); i++)
            {
                int x = rnd.Next(width);
                int y = rnd.Next(height);
                int w = rnd.Next(10);
                int h = rnd.Next(10);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }
            //Remove all of variables from the memory to save resource
            hatchBrush.Dispose();
            g.Dispose();
            //return the image to the related component
            //return bitmap
            byte[] data = default(byte[]);

            using (System.IO.MemoryStream sampleStream = new System.IO.MemoryStream())
            {
                bitmap.Save(sampleStream, System.Drawing.Imaging.ImageFormat.Bmp);
                //the byte array
                data = sampleStream.ToArray();
                string base64String = Convert.ToBase64String(data, 0, data.Length);
                return "data:image/png;base64," + base64String;
            }
        }
        //Random Captcha String        
        public static string RandomString(int option = 0)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string mixed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            switch (option)
            {
                //Sólo Ambos
                case 0:
                    string s1 = new string(Enumerable.Repeat(numbers, 3).Select(s => s[random.Next(s.Length)]).ToArray());
                    string s2 = new string(Enumerable.Repeat(letters, 3).Select(s => s[random.Next(s.Length)]).ToArray());
                    string fs = s1 + s2;
                    return fs;
                //Sólo Números  
                case 1:
                    return new string(Enumerable.Repeat(numbers, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                //Letras   
                case 2:
                    return new string(Enumerable.Repeat(letters, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                default:
                    return new string(Enumerable.Repeat(mixed, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }

        [HttpPost]
        public IActionResult ValidarCaptcha()
        {

            return View("Bienvenido");
        }
    }

}