using System;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.CoordinatorPages
{
    public class StudentsListCoordinatorPage
    {
        public const string PAGE_ID = "students-list-page";

        public static void GoTo()
        {
            PageNavigator.Coordinator.StudentsList.Select();
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

        public static int GetStudentsCount(string countId)
        {
            var countText = Driver.Instance.FindElement(By.Id(countId)).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}
