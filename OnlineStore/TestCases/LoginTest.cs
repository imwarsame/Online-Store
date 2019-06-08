using NUnit.Framework;
using OnlineStore.PageObjects;
using OnlineStore.Pages;
using OnlineStore.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
namespace OnlineStore.TestCases
{
    class LoginTest    {
        [Test]
        public void Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = ConfigurationManager.AppSettings["URL"];

            BrowserFactory.InitBrowser("Firefox");
            BrowserFactory.LoadApplicationURL(ConfigurationManager.AppSettings["URL"]); //AppSettings points to Environment.config Where the URL value is stored
            InitThisPage.HomePage.ClickOnMyAccount();
            InitThisPage.LoginPage.LoginIntoApplication("adfasdfsdf","sfadsfa");

            BrowserFactory.CloseAllDrivers();
        }
    }
}
