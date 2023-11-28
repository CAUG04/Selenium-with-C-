using Arkbox.Web.E2ETests.PageObject.Account;
using NUnit.Framework;

namespace Arkbox.Web.E2ETests.TestCases.Account
{
    [TestFixture]
    public class MultimediaTest : BaseTest
    {
        private MultimediaPage _multimediaPage;

        [SetUp]
        public void BeforeTest_Multimedia()
        {
            var loginPage = new LoginPage(Driver);
            var user = PrivateConfiguration["Configuration:Username"];
            var password = PrivateConfiguration["Configuration:Password"];
            _multimediaPage = loginPage.LoginMultimedia(user, password);
        }


        [Test]
        public void Test_Account_Multimedia()
        {
            _multimediaPage.ClickCreationInput();
            _multimediaPage.ClickMultimediaInput();
            _multimediaPage.SwitchWindowsMultimedia();
            _multimediaPage.ClickSelectInput();
            _multimediaPage.ClickStartUpload();

        }
    }
}
