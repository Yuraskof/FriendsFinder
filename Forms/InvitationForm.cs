using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using LinkedInFriend.Utilities;
using OpenQA.Selenium;

namespace LinkedInFriend.Forms
{
    public class InvitationForm : Form
    {
        private IButton AddNoteButton => ElementFactory.GetButton(By.XPath("//button[@aria-label='Add a note']"), "Add note button");
        private ITextBox MessageTextBox => ElementFactory.GetTextBox(By.XPath("//textarea[@id ='custom-message']"), "Message text box");
        private IButton SendButton => ElementFactory.GetButton(By.XPath("//button[@aria-label =\"Send now\"]"), "Send button");

        

        public InvitationForm() : base(By.XPath("//div[contains (@class,\"artdeco-modal__actionbar\")]"), "Invitation form")
        {
        }

        public void SendInvitation()
        {
            AddNoteButton.State.WaitForEnabled();
            AddNoteButton.Click();
            MessageTextBox.SendKeys(FileUtils.TestData.Message);
            SendButton.State.WaitForEnabled();
            SendButton.Click();
        }
    }
}
