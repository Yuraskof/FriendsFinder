using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace LinkedInFriend.Forms.Pages
{
    public class SearchPage : Form
    {
        private IList<IButton> AllButtons => FormElement.FindChildElements<IButton>(By.XPath("//span[@class = 'artdeco-button__text']"), expectedCount: ElementsCount.MoreThenZero);

        private InvitationForm invitationForm = new InvitationForm();

        public SearchPage() : base(By.XPath("//div[@class = \"entity-result__actions entity-result__divider\"]"), "Search page")
        {
        }

        public void GetTextFromButtons()
        {
            Random random = new Random();

            foreach (var button in AllButtons)
            {
                if (button.Text == "Connect")
                {
                    button.Click();
                    invitationForm.SendInvitation();
                    int timer = random.Next(4, 10);
                    Thread.Sleep(timer);
                }
            }
        }

        //public List<TestModel> GetTestsNames()
        //{
        //    List<TestModel> testModels = new List<TestModel>();

        //    foreach (var testRow in TestsRows)
        //    {
        //        TestModel testModel = new TestModel();
        //        ITextBox testName = testRow.FindChildElement<ITextBox>(By.XPath("//a[contains (text(), '')]"));
        //        string name = testName.GetText();
        //        testModel.Name = name;

        //        ITextBox testSatrtTime = testRow.FindChildElement<ITextBox>(By.XPath("//td[contains (text(), ':')][1]"));
        //        string time = testSatrtTime.GetText();
        //        testModel.StartTime = time;
        //        testModels.Add(testModel);
        //    }
        //    return testModels;
        //}

        //public bool IsProjectSuccessfullyAdded(TestModel model)
        //{
        //    return TestLink(Convert.ToString(model.Id)).State.WaitForEnabled();
        //}

        //public void GoToTestPage(TestModel model)
        //{
        //    TestLink(Convert.ToString(model.Id)).State.WaitForEnabled();
        //    TestLink(Convert.ToString(model.Id)).Click();
        //}
    }
}
