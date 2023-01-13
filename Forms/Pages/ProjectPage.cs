using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExamTaskDockerUiDb.Models;
using OpenQA.Selenium;

namespace ExamTaskDockerUiDb.Forms.Pages
{
    public class ProjectPage : Form
    {
        private ILink TestLink(string testId) => ElementFactory.GetLink(By.XPath(string.Format("//a[@href ='testInfo?testId={0}']", testId)), "Test link");
        private IList<ITextBox> TestsRows => FormElement.FindChildElements<ITextBox>(By.XPath("//span[contains(@class, 'label')]//parent:: td//parent:: tr"), expectedCount: ElementsCount.MoreThenZero);

        public TestPage TestPage = new TestPage();
        
        public ProjectPage() : base(By.XPath("//table[@class ='table']"), "Project page")
        {
        }

        public List<TestModel> GetTestsNames()
        {
            List<TestModel> testModels = new List<TestModel>();

            foreach (var testRow in TestsRows)
            {
                TestModel testModel = new TestModel();
                ITextBox testName = testRow.FindChildElement<ITextBox>(By.XPath("//a[contains (text(), '')]"));
                string name = testName.GetText();
                testModel.Name = name;

                ITextBox testSatrtTime = testRow.FindChildElement<ITextBox>(By.XPath("//td[contains (text(), ':')][1]"));
                string time = testSatrtTime.GetText();
                testModel.StartTime = time;
                testModels.Add(testModel);
            }
            return testModels;
        }

        public bool IsProjectSuccessfullyAdded(TestModel model)
        {
            return TestLink(Convert.ToString(model.Id)).State.WaitForEnabled();
        }

        public void GoToTestPage(TestModel model)
        {
            TestLink(Convert.ToString(model.Id)).State.WaitForEnabled();
            TestLink(Convert.ToString(model.Id)).Click();
        }
    }
}
