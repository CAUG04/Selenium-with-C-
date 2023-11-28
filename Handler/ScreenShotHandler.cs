using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace Arkbox.Web.E2ETests.Handler
{
    //Clase para manejar las capturas de pantalla
    public class ScreenShotHandler
    {
        //Obtener la dirección del directorio donde se va guardatr la imagen
        private static readonly string DirectoryPath = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase);
      
        //Metodo para realizar la captura de la pantalla con Selenium
        //Retorna la dirección de la imagen que se capturo
        public static string TakeScreenShot(IWebDriver driver)
        {
            var milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            var imagePath = DirectoryPath + "//img_" + milliseconds + ".png";
            var image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(imagePath, ScreenshotImageFormat.Png);

            return imagePath;
        }
    }
}

