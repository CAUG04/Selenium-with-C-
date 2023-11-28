using Arkbox.Web.E2ETests.PageObject.Account;
using Arkbox.Web.E2ETests.PageObject.Users;
using NUnit.Framework;

namespace Arkbox.Web.E2ETests.TestCases.Users
{
    // Clase  que contiene los casos de pruebas del formulario de Usuario
    [TestFixture] // Anotación de NUnit para marcar una clase que contenga casos de prueba
    public class UserListTest : BaseTest
    {
        //Page Object para el formulario UserList
        private UserListPage _userListPage;

        //Setup anotación de Nunit para ejecutar un metodo antes de cada test
        // Metodo para loguearse en la aplicación.
        [SetUp]
        public void BeforeTest()
        {
            var loginPage = new LoginPage(Driver);
            var user = PrivateConfiguration["Configuration:Username"];
            var password = PrivateConfiguration["Configuration:Password"];
            _userListPage = loginPage.LoginAs(user, password);
        }

        //TestCase: Anotación de NUnit para marcar a un metodo como un caso de prueba automatizado con parametros
        // Metodo que implementa el caso de prueba de adicionar usuario. El resultado es que el usuario se agregue o invite correctamente
        [TestCase("Usuario de cuenta", "Super Administrador | Todos los permisos", "c.urrego78@pascualbravo.edu.co")]
        [TestCase("Usuario de cuenta", "Super Administrador | Todos los permisos", "carlos.urrego@tekus.co")]
        public void AddUserTest(string userType, string profile, string email)
        {
            _userListPage.ClickSecurityInput();
            _userListPage.ClickUserListInput();
            _userListPage.ClickOpenInvitation();
            _userListPage.AddUser(userType, profile, email);

            //Assert.IsTrue(_userListPage.IsSuccessAlertPresent());
        }
    }
}