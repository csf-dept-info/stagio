using System;

using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;

using OpenQA.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipApplicationPages
{
    public class CoordinatorIndexInternshipApplicationPage
    {
        public const string PAGE_ID = "application-index-page";
        public const string PAGE_TITLE = "Candidatures pour l'offre de stage";

        public static void GoTo()
        {
            PageNavigator.InternshipApplication.CoordinatorIndex.Select();
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

        public static int GetApplicationsCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("application-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}
