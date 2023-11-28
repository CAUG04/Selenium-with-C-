using Arkbox.Web.E2ETests.Handler;
using OpenQA.Selenium;
using System;

namespace Arkbox.Web.E2ETests.PageObject.Users
{
    // Clase para la lista de usuarios
    public class UserListPage : BasePage
    {
        //localizadores
        protected By SecurityInput = By.XPath("//html/body/div[2]/aside/div/nav/ul/li[7]/a/span");
        protected By UserListInput = By.XPath("//*[@id='menuUsers']/li[2]/a/span");
        protected By OpenInvitation = By.XPath("//button[@class='btn btn-sm btn-success']");
        protected By Form = By.XPath("//form[@name='Invitation']");
        protected By UserInput = By.Id("select2-UserType-container");
        protected By ProfileInput = By.XPath("//html/body/div[1]/div/div/div[2]/form/div[3]/div/div/span/span[1]/span");
        protected By EmailInput = By.XPath("//input[@ng-model='Email']");
        protected By SendButton = By.XPath("//button[@ng-click='sendInvitation(Invitation)']");

        /// <summary>
        /// Constructor. Lanza una excepción si el titulo de la página del formulario Usuario no es el correcto
        /// </summary>
        /// <param name="driver"></param>
        public UserListPage(IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("Arkbox - Index"))
                throw new Exception("this is not the login page");
        }
        public void ClickSecurityInput()
        {
            Driver.FindElement(SecurityInput).Click();
        }

        public  void ClickUserListInput()
        {
            Driver.FindElement(UserListInput).Click();
        }
        /// <summary>
        /// Método para escribir el botón de Invitar a un usuario
        /// </summary>
        public void ClickOpenInvitation()
        {
            Driver.FindElement(OpenInvitation).Click();
        }
        
        //Metodo para detectar si el formulario del listado de usuarios esta cargado
        //retorna True si el elemento del formulario esta presente sino retorna false
        public bool FormIsPresent()
        {
            return WaitHandler.ElementIsPresent(Driver, Form);
        }

        //Metodo que permite adicionar Usuarios
        public void AddUser(string userType, string profile, string email)
        {
            Driver.FindElement(UserInput).Click();
            Driver.FindElement(By.XPath("//li[text()='" + userType + "']")).Click();
            Driver.FindElement(ProfileInput).Click();
            Driver.FindElement(By.XPath("//li[text()='" + profile + "']")).Click();
            Driver.FindElement(EmailInput).SendKeys(email);
            Driver.FindElement(SendButton).Click();
        }

        //Metodo para capturar y aceptar una alertas
        //Retorna true si se detecta una alerta y es aceptada, sino retorna falso
        //public bool IsSuccessAlertPresent()
        //{
        //    try
        //    {
        //        Driver.SwitchTo().Alert().Accept();
        //        return true;
        //    }
        //    catch (NoAlertPresentException)
        //    { }
        //    return false;
        //}
    }
}
