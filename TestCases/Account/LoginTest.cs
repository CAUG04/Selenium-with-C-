using Arkbox.Web.E2ETests.PageObject.Account;
using NUnit.Framework;

namespace Arkbox.Web.E2ETests.TestCases.Account
{
    //Clase que contiene los de prueba del Login
    [TestFixture] //Anotación de Nunit para marcar una clase que contenga casos de prueba
    public class LoginTest : BaseTest
    {
        //Test: Anotación de NUnit para marcar a un metodo como un caso de prueba automatizado
        // Metodo que implementa el caso de prueba del Login. El resultado es que el usuario se loguee correctamente
        [Test]
        public void Test_Account_Login_Success()
        {
            var loginPage = new LoginPage(Driver);
            var user = PrivateConfiguration["Configuration:Username"]; //
            var password = PrivateConfiguration["Configuration:Password"];
            var userListPage = loginPage.LoginAs(user, password);
            var channelsPage = loginPage.LoginChannels(user, password);
           
            Assert.IsTrue(userListPage.FormIsPresent());
            Assert.IsTrue(channelsPage.FormIsPresent());
        }
    }
}