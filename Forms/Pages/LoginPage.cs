using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace LinkedInFriend.Forms.Pages
{
    public class LoginPage : Form
    {
        private IButton AcceptCookiesButton => ElementFactory.GetButton(By.XPath("//button[@action-type= 'ACCEPT']"), "Accept cookies button");
        private IButton LoginButton => ElementFactory.GetButton(By.XPath("//button[@class = 'sign-in-form__submit-button']"), "Login button");
        private ITextBox LoginTextBox => ElementFactory.GetTextBox(By.XPath("//input[@autocomplete = 'username']"), "Login text box");
        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//input[@autocomplete = 'current-password']"), "Password text box");


        public LoginPage() : base(By.XPath("//button[@class = 'sign-in-form__submit-button']"), "Login page")
        {
        }
        
        public void AcceptCookies()
        {
            AcceptCookiesButton.State.WaitForEnabled();
            AcceptCookiesButton.Click();
        }

        public void Login(string login, string password)
        {
            FillCreds(login, password);

            LoginButton.State.WaitForEnabled();
            LoginButton.Click();
        }

        private void FillCreds(string login, string password)
        {
            LoginTextBox.State.WaitForEnabled();
            LoginTextBox.SendKeys(login);

            PasswordTextBox.State.WaitForEnabled();
            PasswordTextBox.SendKeys(password);

        }
    }
}