using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace OnlineStore.Pages
{
    public class HomePage 
    {
        private IWebDriver driver;

        //init our page and elements
       /* Below constructor was refactored into the InitThisPage class
       public HomePage(IWebDriver driver)
       {
     
          ---this.driver refers to the private instance field delcared on line 9 of this class
          ---when we create a new HomePage object, in our tests,we pass in the driver i.e. Chrome or Firefox
          ---and PageFactory.InitElement will initialise all the elements on the choosen driver
        
          this.driver = driver;
          PageFactory.InitElements(driver, this);
        }
       */

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

