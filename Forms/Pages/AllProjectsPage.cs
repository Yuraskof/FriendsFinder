using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTaskDockerUiDb.Forms.Pages
{
    public class AllProjectsPage : Form
    {
        private ITextBox FooterTextBox => ElementFactory.GetTextBox(By.XPath("//*[contains(@class, 'footer-text')]//span"), "Footer text box");
        private IButton ProjectButton(string project) => ElementFactory.GetButton(By.XPath(string.Format("//div[@class='list-group']//a[contains(text(), '{0}')]", project)), "Project button");
        private IButton AddButton => FormElement.FindChildElement<IButton>(By.XPath("//button[contains(@class, 'btn-primary')]"), "Add project button");
        private IWebElement IFrame => AqualityServices.Browser.Driver.FindElement(By.Id("addProjectFrame"));
        

        public AddProjectForm AddProjectForm = new AddProjectForm();

        public AllProjectsPage() : base(By.XPath("//div[contains (@class, 'panel-default')]//div[contains (text(), 'projects')]"), "Projects page")
        {
        }
        
        public string GetFooterText()
        {
            FooterTextBox.State.WaitForEnabled();
            return FooterTextBox.GetText();
        }

        public void GoToProjectPage(string project)
        {
            ProjectButton(project).State.WaitForEnabled();
            ProjectButton(project).Click();
        }

        public void OpenAddProjectForm()
        {
            AddButton.State.WaitForEnabled();
            AddButton.Click();
            
        }

        public void SwitchToNewFrame()
        {
            AqualityServices.Browser.Driver.SwitchTo().Frame(IFrame);
        }

        public void CloseAddProjectForm()
        {
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
            AqualityServices.Browser.Driver.ExecuteScript("closePopUp()", IFrame);
        }

        public bool IsProjectPresented(string projectName)
        {
            return ProjectButton(projectName).State.WaitForEnabled();
        }
    }
}