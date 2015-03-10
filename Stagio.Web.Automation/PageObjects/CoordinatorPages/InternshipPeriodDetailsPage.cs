using System;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.CoordinatorPages
{
    public class InternshipPeriodDetailsPage
    {
        public const string PAGE_ID = "period-details-page";

        public static void GoTo()
        {
            PageNavigator.Coordinator.PeriodsList.Select();
            Driver.Instance.FindElement(By.Id("period-details-1")).Click();
        }

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
    }
}
