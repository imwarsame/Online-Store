using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace OnlineStore.Pages
{
    public class HomePage 
    {
        private IWebDriver driver;

        //init our page and elements
       

        //Elements -  the Page Factory way
        [FindsBy(How = How.Id, Using = "account")]
        [CacheLookup]
       /* Making elements private for the purpose of encapsulation: 
        * These elements can only be accessed by other classes via public methods of this class
        */
        private IWebElement MyAccount { get; set; } //get and set because we'll be gettinga and setting(changing) this web element later in our tests

        //methods
        public void ClickOnMyAccount()
        {
            MyAccount.Click();
        }
    }
}

