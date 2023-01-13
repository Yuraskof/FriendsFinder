using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTaskDockerUiDb.Forms
{
    public class AddProjectForm : Form
    {
        private ITextBox ProjectNameTextBox => ElementFactory.GetTextBox(By.Id("projectName"), "Project name");
        private IButton SubmitButton => ElementFactory.GetButton(By.XPath("//button[@type ='submit']"), "Submit button");
        private ITextBox SuccessTextBox => ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'alert-success')]"), "Success add message");
        
        public AddProjectForm() : base(By.Id("addProjectForm"), "Add project form") 
        {
        }

        public void AddProject(string name)
        { 
            EnterName(name);
            SubmitButton.Click();
        }

        public bool IsProjectSuccessfullyAdded()
        {
            return SuccessTextBox.State.WaitForEnabled();
        }

        private void EnterName(string name)
        {
            ProjectNameTextBox.State.WaitForEnabled();
            ProjectNameTextBox.ClearAndType(name);
        }
    }
}
