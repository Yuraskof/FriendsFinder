using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using LinkedInFriend.Utilities;
using OpenQA.Selenium;

namespace LinkedInFriend.Forms
{
    public class MainNavigationForm : Form
    {
        private IButton SearchButton => ElementFactory.GetButton(By.Id("global-nav-typeahead"), "Search button");
        private ITextBox SearchTextBox => ElementFactory.GetTextBox(By.XPath("//input[@class='search-global-typeahead__input']"), "Search text box");
        private IButton AllPeopleButton => ElementFactory.GetButton(By.XPath("//a[contains (text(), 'See all people results')]"), "All people button");
        
        public MainNavigationForm() : base(By.Id("global-nav-typeahead"), "Main navigation form") 
        {
        }

        public void SearchText()
        {
            SearchButton.State.WaitForEnabled();
            SearchButton.Click();
            SearchTextBox.SendKeys(FileUtils.TestData.SearchText + Keys.Enter);
        }

        public void ExpandAllPeople()
        {
            AllPeopleButton.Click();
        }
    }
}
