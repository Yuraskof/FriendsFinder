using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using LinkedInFriend.Utilities;
using OpenQA.Selenium;

namespace LinkedInFriend.Forms.Pages
{
    public class SearchPage : Form
    {
        private IList<IButton> AllButtons => FormElement.FindChildElements<IButton>(By.XPath("//span[@class = 'artdeco-button__text']"), expectedCount: ElementsCount.MoreThenZero);
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//button[contains(@aria-label, 'Next')]"), "Next button");
        

        private InvitationForm invitationForm = new InvitationForm();

        public SearchPage() : base(By.XPath("//div[@class = \"entity-result__actions entity-result__divider\"]"), "Search page")
        {
        }

        public void AddContacts()
        {

            Random random = new Random();
            int invitationsSendCounter = 0;

            try
            {
                while (invitationsSendCounter < FileUtils.TestData.MaxInvitationsCount)
                {
                    foreach (var button in AllButtons)
                    {
                        if (button.Text == "Connect")
                        {
                            button.Click();
                            invitationForm.SendInvitation();
                            int timer = random.Next(2000, 5000);
                            Thread.Sleep(timer);
                            invitationsSendCounter++;
                        }
                    }

                    AllButtons[^1].JsActions.ScrollIntoView();
                    GoToTheNextPage();
                }
            }
            catch (Exception e)
            {
                AqualityServices.Browser.Driver.GetScreenshot().SaveAsFile("../../../exScreen.jpg");
                Logger.Error(e.Message + " See screenshot");
            }
            
        }

        private void GoToTheNextPage()
        {
            NextButton.State.WaitForEnabled();
            NextButton.Click();
        }
    }
}
