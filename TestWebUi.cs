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
                string screenshotName = DateTime.Now.ToString("dd/MM HH-mm-ss");
                AqualityServices.Browser.Driver.GetScreenshot().SaveAsFile($"../../../exScreen {screenshotName}.jpg");
                LoggerUtils.Logger.Error(e.Message + $" See screenshot {screenshotName}");
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