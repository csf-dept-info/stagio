using System;

using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;

using OpenQA.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipApplicationPages
{
    public class StudentIndexInternshipApplicationPage
    {
        public const string PAGE_ID = "student-application-index-page";
        public const string PAGE_TITLE = "Mes candidatures de stage";
        public const string UPDATE_PROGRESSION_BUTTON_ID = "update-progression-button-";
        public const string UPDATE_PROGRESSION_CONFIRM_BUTTON_ID = "update-progression-confirm-button-";

        public static void GoTo()
        {
            PageNavigator.InternshipApplication.StudentIndex.Select();
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

        public static bool HasContent(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.Id(PAGE_ID));

            return body.Text.Contains(textToFind);
        }

        public static bool HasFeedBackMessage(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.Id("flash-messages"));

            return body.Text.Contains(textToFind);
        }

        public static void UpdateProgression(int applicationId, DateTime date)
        {
            Driver.Instance.FindElement(By.Id(UPDATE_PROGRESSION_BUTTON_ID + applicationId)).Click();

            Driver.Instance.FindElement(By.Id("item_LastProgressionUpdateDate")).Clear();
            Driver.Instance.FindElement(By.Id("item_LastProgressionUpdateDate")).SendKeys(date.ToShortDateString());

            Driver.Instance.FindElement(By.Id(UPDATE_PROGRESSION_CONFIRM_BUTTON_ID + applicationId)).Click();
        }
    }
}
