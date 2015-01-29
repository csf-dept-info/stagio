using System;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.CoordinatorPages
{
    public class CleanDatabasePage
    {
        public const string PAGE_ID = "clean-database-page";

        public static void GoTo()
        {
            PageNavigator.Coordinator.CleanDatabase.Select();
        }


        public static void ClickCleanDatabaseButton()
        {

            Driver.Instance.FindElement(By.Id("submit-clean-database-button")).Click();
        }

        public static void FillPasswordValidation(string password)
        {
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(password);
            Driver.Instance.SwitchTo().ActiveElement();
        }

        public static void ClickCleanDatabaseModalButton()
        {
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.FindElement(By.Id("delete-draft-validation-button")).Click();
            Driver.Instance.SwitchTo().ActiveElement();
        }
    }
}
