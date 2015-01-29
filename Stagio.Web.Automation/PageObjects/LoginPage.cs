using System;

using Stagio.Domain.Entities;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;

using OpenQA.Selenium;


namespace Stagio.Web.Automation.PageObjects
{
    public class LoginPage
    {
        public const string PAGE_ID = "login-page";

        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id(PAGE_ID));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool HasContent(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.Id(PAGE_ID));

            return body.Text.Contains(textToFind);
        }

        public static void GoTo()
        {
            PageNavigator.AllUsers.Login.Select();
        }

        public static void LoginAs(ApplicationUser user)
        {
            Driver.Instance.FindElement(By.Id("Identifier")).SendKeys(user.Identifier);

            Driver.Instance.FindElement(By.Id("Password")).SendKeys(user.Password);

            Driver.Instance.FindElement(By.Id("login-submit")).Click();
        }
    }
}
