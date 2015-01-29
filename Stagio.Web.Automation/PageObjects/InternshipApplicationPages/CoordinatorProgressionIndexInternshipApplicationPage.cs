using System;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipApplicationPages
{
    public class CoordinatorProgressionIndexInternshipApplicationPage
    {
        public const string PAGE_ID = "application-coordinator-index-page";
        public const string PAGE_TITLE = "Suivi des candidatures";

        public static void GoTo()
        {
            PageNavigator.InternshipApplication.CoordinatorProgressionIndex.Select();
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

        public static void SeeStudentApplications()
        {
            const int STUDENT_ID = 1;
            PageNavigator.InternshipApplication.CoordinatorProgressionIndex.DisplayStudentApplications(STUDENT_ID);
        }
    }
}