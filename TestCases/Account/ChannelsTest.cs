using Arkbox.Web.E2ETests.PageObject.Account;
using NUnit.Framework;

namespace Arkbox.Web.E2ETests.TestCases.Account
{
    public class ChannelsTest : BaseTest
    {
        private ChannelsPage _channelsPage;

        [SetUp]
        public void BeforeTest_Channels()
        {
            var loginPage = new LoginPage(Driver);
            var user = PrivateConfiguration["Configuration:Username"];
            var password = PrivateConfiguration["Configuration:Password"];
            _channelsPage = loginPage.LoginChannels(user, password);
        }

        [Test]
        public void Add_Channels_Test()
        {
            _channelsPage.ClickCreationInput();
            _channelsPage.ClickChannelsInput();
            _channelsPage.ClickCreateChannels();
        }
    }
}
