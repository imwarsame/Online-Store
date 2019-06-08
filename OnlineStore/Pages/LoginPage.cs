using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OnlineStore.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        //init our page and elements

        //elements
        [FindsBy(How = How.Id, Using = "log")]
        [CacheLookup]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "pwd")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        public IWebElement Submit { get; set; }

        //methods
        public void LoginIntoApplication(string username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            Submit.Submit();
        }

    }
}
