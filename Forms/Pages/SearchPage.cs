using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using LinkedInFriend.Utilities;
using OpenQA.Selenium;
using System.Linq;

namespace LinkedInFriend.Forms.Pages
{
    public class SearchPage : Form
    {
        private IList<IButton> AllButtons => FormElement.FindChildElements<IButton>(By.XPath("//span[@class = 'artdeco-button__text']"), expectedCount: ElementsCount.MoreThenZero);
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//button[contains(@aria-label, 'Next')]"), "Next button");
        private IList<ITextBox> AllDescriptionTextBoxes => FormElement.FindChildElements<ITextBox>(By.XPath("//span[@class = 'artdeco-button__text']//preceding::div[contains(@class,\"entity-result__primary-subtitle\")]"), expectedCount: ElementsCount.MoreThenZero);
        private IList<ITextBox> AllSummaryTextBoxes => FormElement.FindChildElements<ITextBox>(By.XPath("//span[@class = 'artdeco-button__text']//preceding::p[contains(@class,\"entity-result__summary\")]"), expectedCount: ElementsCount.MoreThenZero);
        private IButton CloseMessageButton => ElementFactory.GetButton(By.XPath("//button[contains(@class, \"msg-overlay-bubble-header__control\")]//li-icon[@type = \"close\"]"), "Close message button");

        private InvitationForm invitationForm = new InvitationForm();
        private string[] IgnoreList = FileUtils.TestData.IgnoreText.Split(",");

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
                    try
                    {
                        if (AllButtons.Count != AllDescriptionTextBoxes.Count || AllButtons.Count != AllSummaryTextBoxes.Count)
                        {
                            GoToTheNextPage();
                            Logger.Info($"AllButtons.Count = {AllButtons.Count}, AllDescriptionTextBoxes.Count = {AllDescriptionTextBoxes.Count}, AllSummaryTextBoxes.Count = {AllSummaryTextBoxes.Count}");
                        }
                    }
                    catch (Exception e)
                    {
                        AqualityServices.Browser.Refresh();
                    }
                    

                    for (int i = 0; i < AllButtons.Count; i++)
                    {
                        if (AllButtons[i].Text == "Connect")
                        {
                            if (IsContainsInIgnoreList(i))
                            {
                                continue;
                            }

                            try
                            {
                                AllButtons[i].Click();
                            }
                            catch (Exception e)
                            {
                                CloseMessageButton.State.WaitForEnabled();
                                CloseMessageButton.Click();
                                AllButtons[i].State.WaitForEnabled();
                                AllButtons[i].Click();

                            }
                            

                            try
                            {
                                invitationForm.SendInvitation();
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                            
                            int timer = random.Next(2000, 5000);
                            Thread.Sleep(timer);
                            invitationsSendCounter++;
                        }
                    }

                    GoToTheNextPage();
                }

                LoggerUtils.Logger.Info($"Sent {invitationsSendCounter} invitations.");
            }
            catch (Exception e)
            {
                string screenshotName = DateTime.Now.ToString("dd/MM HH-mm-ss");
                AqualityServices.Browser.Driver.GetScreenshot().SaveAsFile($"../../../exScreen {screenshotName}.jpg");
                LoggerUtils.Logger.Error(e.Message + $" See screenshot {screenshotName}");
                throw;
            }
        }

        private bool IsContainsInIgnoreList(int number)
        {
            string descriptionText;
            string summaryText;

            try
            {
                 descriptionText = AllDescriptionTextBoxes[number].Text.ToLower();
                 summaryText = AllSummaryTextBoxes[number].Text.ToLower();
            }
            catch (Exception e)
            {
                return false;
            }
            

            foreach (var item in IgnoreList)
            {
                if (descriptionText.Contains(item.ToLower()) || summaryText.Contains(item.ToLower()))
                {
                    return true;
                }
            }
            
            return false;
        }

        private void GoToTheNextPage()
        {
            try
            {
                AllButtons[^1].JsActions.ScrollIntoView();
                NextButton.State.WaitForEnabled();
                NextButton.Click();
            }
            catch (Exception e)
            {
                CloseMessageButton.State.WaitForEnabled();
                CloseMessageButton.Click();

                AllButtons[^1].JsActions.ScrollIntoView();
                NextButton.State.WaitForEnabled();
                NextButton.Click();
            }
        }
    }
}
