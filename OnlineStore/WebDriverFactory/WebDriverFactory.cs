using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace OnlineStore.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> ListOfDrivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driverForTesting;

        public static IWebDriver Driver
        {
            get
            {
                if (driverForTesting == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driverForTesting;
            }
            private set
            {
                driverForTesting = value;
                //sets driverForTesting to which ever browser name is returned. 
            }
        }

        /// <summary>
        /// Sets the webdriver to the one passed in the parameter
        /// </summary>
        /// <param name="browserName"></param>
        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (Driver == null) //condition here is null bc we don't want to re-init the browser again, so we check init is null, first
                    {
                        driverForTesting = new FirefoxDriver();
                        ListOfDrivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        driverForTesting = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        ListOfDrivers.Add("IE", Driver);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        driverForTesting = new ChromeDriver();
                        ListOfDrivers.Add("Chrome", Driver);
                    }
                    break;
            }
        }

        /// <summary>
        ///  Points the driver to the given url
        /// </summary>
        /// <param name="url">the endpoint used by the driver to carry out the automated tests</param>
        public static void LoadApplicationURL(string url)
        {
            Driver.Url = url;
        }

        /// <summary>
        /// Closes and quits all drivers
        /// </summary>
        public static void CloseAllDrivers()
        {
            foreach (var key in ListOfDrivers.Keys)
            {
                ListOfDrivers[key].Close();
                ListOfDrivers[key].Quit();
            }
        }
    }
}