using OpenQA.Selenium;
using System;
using Arkbox.Web.E2ETests.Handler;

namespace Arkbox.Web.E2ETests.PageObject.Account
{
    public class ChannelsPage : BasePage
    {
        //Localizadores
        protected By CreationInput = By.XPath("//html/body/div[2]/aside/div/nav/ul/li[3]/a/span");
        protected By ChannelsInput = By.XPath("//*[@id='menuCreation']/li[4]/a/span");
        protected By CreateChannelsInput = By.XPath("//button[@class='btn-sm btn btn-success']");
        protected By Form = By.XPath("//form[@name='channelInfo']");
        protected By NameInput = By.XPath("//input[@name='Description']");
        protected By DetailsInput = By.XPath("//input[@name='Details']");
        protected By ResolutionsInput = By.Id("select2 - IdType - container");
        protected By StretchInput = By.Id("select2-Stretch-container");
        protected By SaveInput = By.XPath("//button[@class='btn-sm btn btn-success ladda-button']");

        public ChannelsPage(IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("Arkbox - Index"))
                throw new Exception("this is not the login page");
        }

        public void ClickCreationInput()
        {
            Driver.FindElement(CreationInput).Click();
        }

        public void ClickChannelsInput()
        {
            Driver.FindElement(ChannelsInput).Click();
        }

        public void ClickCreateChannels()
        {
            Driver.FindElement(CreateChannelsInput).Click();
        }

        public bool FormIsPresent()
        {
            return WaitHandler.ElementIsPresent(Driver, Form);
        }

        public void AddChannels()
        {
            Driver.FindElement(NameInput).SendKeys("Pruebas Carlos Selenium");
            Driver.FindElement(DetailsInput).SendKeys("Esté es un canal donde se hacen pruebas - Selenium");
            Driver.FindElement(ResolutionsInput).Click();
            Driver.FindElement(By.Id("select2-IdType-result-pwbs-22")).Click(); 
        }
    }
}
