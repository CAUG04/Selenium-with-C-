using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Arkbox.Web.E2ETests.PageObject.Account
{
    public class MultimediaPage : BasePage
    {
        //Localizadores
        protected By CreationInput = By.XPath("//html/body/div[2]/aside/div/nav/ul/li[3]/a/span");
        protected By MultimediaInput = By.XPath("//*[@id='menuCreation']/li[2]/a/span");
        protected By OpenUploadFile = By.XPath("//button[@class='btn-sm btn btn-success']");
        protected By SelectMediaInput = By.XPath("//*[@id='dropArea']/div[2]/span/div/a");
        protected By StartUploadInput = By.XPath("//html/body/div[2]/div[1]/button[1]");

        public MultimediaPage(IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("Arkbox - Index"))
                throw new Exception("this is not the login page");
        }

        public void ClickCreationInput()
        {
            Driver.FindElement(CreationInput).Click();
        }

        public void ClickMultimediaInput()
        {
            Driver.FindElement(MultimediaInput).Click();
        }

        public void SwitchWindowsMultimedia()
        {
            //Store the ID of the original window
            string originalWindow = Driver.CurrentWindowHandle;

            //Check we don't have other windows open already
            Assert.AreEqual(Driver.WindowHandles.Count, 1);
            Driver.FindElement(OpenUploadFile).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            //Wait for the new window or tab
            wait.Until(wd => wd.WindowHandles.Count == 2);

            //Loop through until we find a new window handle
            foreach (string window in Driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    Driver.SwitchTo().Window(window);
                    break;
                }
            }
            //Wait for the new tab to finish loading content
            wait.Until(wd => wd.Title == "Arkbox - Digital Signage");
        }

        public void ClickSelectInput()
        {
            IWebElement uploadFile = Driver.FindElement(SelectMediaInput);
            Thread.Sleep(5000);
            uploadFile.SendKeys(@"‪C:\Users\Carlos.urrego\Documents\Background.png" + Keys.Enter);
        }

        public void ClickStartUpload()
        {
            Driver.FindElement(StartUploadInput).Click();
            Thread.Sleep(10000);
        }
    }
}
