using System;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects
{
    public class HomePage
    {
        public const string HOME_PAGE_MESSAGE = "Mon compte Stagio";
        public const string EMPLOYEE_LOGGED_IN_ID = "employee-index-page";
        public const string STUDENT_LOGGED_IN_ID = "student-index-page";
        public const string COORDINATOR_LOGGED_IN_ID = "coordinator-index-page";

        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    if (IsEmployeeLogged)
                    {
                        Driver.Instance.FindElement(By.Id("employee_index_page"));
                    }
                    if (IsCoordinatorLogged)
                    {
                        Driver.Instance.FindElement(By.Id("coordinator_index_page"));
                    }
                    if (IsStudentLogged)
                    {
                        Driver.Instance.FindElement(By.Id("student-index-page"));
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static void GoTo()
        {
            PageNavigator.AllUsers.Home.Select();
        }

        public static bool HasFeedBackMessage(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.Id("flash-messages"));

            return body.Text.Contains(textToFind);
        }

        public static bool IsEmployeeLogged
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id(EMPLOYEE_LOGGED_IN_ID));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool IsCoordinatorLogged
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id(COORDINATOR_LOGGED_IN_ID));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool IsStudentLogged
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id(STUDENT_LOGGED_IN_ID));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
