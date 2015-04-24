using System;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.CoordinatorPages
{
    public class PeriodsListPage
    {
        public const string PAGE_ID = "periods-list-page";

        public static void GoTo()
        {
            PageNavigator.Coordinator.PeriodsList.Select();
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

        public static int GetArchivesCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("periods-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}
