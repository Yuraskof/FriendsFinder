using Aquality.Selenium.Browsers;
using LinkedInFriend.Base;
using LinkedInFriend.Forms;
using LinkedInFriend.Forms.Pages;
using LinkedInFriend.Utilities;


namespace LinkedInFriend
{
    public class TestWebUi:BaseTest
    {
        [Test(Description = "ET-0001 Checking the website functionality using UI and Database")]
        public void TestWebUiAndDatabase()
        {
            AqualityServices.Browser.GoTo(FileUtils.TestData.Url);
            AqualityServices.Browser.Maximize();

            LoginPage loginPage = new();
            Assert.IsTrue(loginPage.State.WaitForDisplayed(), $"{loginPage.Name} should be presented");
            
            loginPage.AcceptCookies();
            loginPage.Login(FileUtils.LoginUser.Login, FileUtils.LoginUser.Password);

            MainNavigationForm mainNavigationForm = new MainNavigationForm();

            mainNavigationForm.SearchText();
            mainNavigationForm.ExpandAllPeople();

            SearchPage searchPage = new SearchPage();

            try
            {
                searchPage.AddContacts();
            }
            catch (Exception e)
            {
                AqualityServices.Browser.Driver.GetScreenshot().SaveAsFile($"../../../exScreen{DateTime.Now.Millisecond}.jpg");
                LoggerUtils.Logger.Error(e.Message + " See screenshot");
                AqualityServices.Browser.Refresh();
                searchPage.AddContacts();
            }


            LoggerUtils.Logger.Info("Invitations are sent");

            //mainNavigationForm.GoToAllMessages();

            //MessagesPage messagesPage = new MessagesPage();

            //messagesPage.GetMessages();

            //messagesPage.SendSecondMessage();

        }
    }
}