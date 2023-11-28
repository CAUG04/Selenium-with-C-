using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Arkbox.Web.E2ETests.Handler
{
    //Clase para manejar las esperar explicitas
    public class WaitHandler
    {
        //Método para esperar por un elemento presente en la pag web
        //Retorna tru si se encuentra el elemento el máximo 3 segundos sino retorna false
        public static bool ElementIsPresent(IWebDriver driver, By locator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(drv => drv.FindElement(locator));

                return true;
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Pana no esta cargando lo que es");
            }
            return false;
        }
    }
}