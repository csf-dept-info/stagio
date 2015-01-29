using System;
using OpenQA.Selenium;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.CoordinatorPages
{
    public class ChoosePeriodCoordinatorPage
    {
        public const string PAGE_ID = "choose-period-page";

        public static void GoTo()
        {
            PageNavigator.Coordinator.ChoosePeriod.Select();
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

        public static void FillForm()
        {
            Driver.Instance.FindElement(By.Id("start-date-picker")).Clear();
            Driver.Instance.FindElement(By.Id("end-date-picker")).Clear();
            Driver.Instance.FindElement(By.Id("start-date-picker")).Click();
            Driver.Instance.FindElement(By.Id("start-date-picker")).SendKeys(String.Format("{0:yyyy-MM-dd}", TestData.InvalidInternshipPeriod.StartDate));
            Driver.Instance.FindElement(By.Id("end-date-picker")).Click();
            Driver.Instance.FindElement(By.Id("end-date-picker")).SendKeys(String.Format("{0:yyyy-MM-dd}", TestData.InvalidInternshipPeriod.EndDate));
            Driver.Instance.FindElement(By.Id("panel-header")).Click();
            Driver.Instance.FindElement(By.Id("choose-period-button")).Click();
        }
    }
}
