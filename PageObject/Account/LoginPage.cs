using Arkbox.Web.E2ETests.PageObject.Users;
using OpenQA.Selenium;
using System;

namespace Arkbox.Web.E2ETests.PageObject.Account
{
    //Clase para el Login
    public class LoginPage : BasePage
    {
        // Localizadores
        protected By UserInput = By.Id("UserName");
        protected By PasswordInput = By.Id("Password");
        protected By LoginButton = By.XPath("/html/body/div/div/div/div/div[2]/form/button");

        //Constructor lanza la excepción si el titulo de la página del Login no es el correcto
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("Arkbox - Digital Signage"))
                throw new Exception("this is not the login page");
        }
        /// <summary>
        /// Método para escribir el usuario
        /// </summary>
        /// <param name="user">Usuario para la prueba</param>
        public void TypeUserName(string user)
        {
            Driver.FindElement(UserInput).SendKeys(user);
        }
        /// <summary>
        /// Método para escribir el contraseña
        /// </summary>
        /// <param name="password"></param>
        public void TypePassword(string password)
        {
            Driver.FindElement(PasswordInput).SendKeys(password);
        }
        /// <summary>
        /// Método para escribir el boton de Login
        /// </summary>
        public void ClickLoginButton()
        {
            Driver.FindElement(LoginButton).Click();
        }

        //Método para hacer Login y retorne la lista de usuarios
        public UserListPage LoginAs(string user, string password)
        {
            TypeUserName(user);
            TypePassword(password);
            ClickLoginButton();

            return new UserListPage(Driver);
        }

        //Método para hacer Login en la página de Multimedia
        public MultimediaPage LoginMultimedia(string user, string password)
        {
            TypeUserName(user);
            TypePassword(password);
            ClickLoginButton();

            return new MultimediaPage(Driver);
        }

        //Método para hacer Login en la página de Canales
        public ChannelsPage LoginChannels(string user, string password)
        {
            TypeUserName(user);
            TypePassword(password);
            ClickLoginButton();

            return new ChannelsPage(Driver);
        }
    }
}

