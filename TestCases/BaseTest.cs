using Arkbox.Web.E2ETests.Handler;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Arkbox.Web.E2ETests.TestCases
{
    //Clase para todos los Test
    public abstract class BaseTest
    {
        //Selenium Driver
        [ThreadStatic] //Atributo para que cada test tenga su propio WebDriver
        protected static IWebDriver Driver;
        public readonly IConfiguration Configuration;
        public readonly IConfiguration PrivateConfiguration;

        protected BaseTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"AppSettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"PrivateSettings.json", optional: true, reloadOnChange: true);
            PrivateConfiguration = builder.Build();
        }
        //Setup anotación de Nunit para ejecutar un metodo antes de cada test
        // Metodo para iniciar el navegador Chrome  y navegar a una Url 
        [SetUp]
        public void BeforeBaseTest()
        {
            var options = new ChromeOptions();
            options.AddArguments("--lang=es"); //español
            var url = PrivateConfiguration["Configuration:Url"];
            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Navigate().GoToUrl(url);
        }

        //TearDown: Anotación deNUnit para ejcuatar un metodo despues de cada test
        //Metodo para cerrar el navegador y hacer una captura de pantalla si el Test falla
        [TearDown]
        public void AfterBaseTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
                ScreenShotHandler.TakeScreenShot(Driver);

            Driver?.Quit();
        }
    }
}
