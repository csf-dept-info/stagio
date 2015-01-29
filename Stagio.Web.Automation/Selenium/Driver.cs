using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Stagio.Web.Automation.Selenium
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress
        {
            get { return "http://cartel-progue.local/Ci"; }
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();

            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            Instance.Navigate().GoToUrl(BaseAddress);

            Instance.Manage().Window.Maximize();
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}