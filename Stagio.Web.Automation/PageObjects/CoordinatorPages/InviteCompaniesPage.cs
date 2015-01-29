using System;
using OpenQA.Selenium;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.CoordinatorPages
{
    public class InviteCompaniesPage
    {
        public const string PAGE_ID = "invite-companies-page";
        public const string PAGE_TITLE = "Inviter les entreprises à s'inscrire au système";
        public const string MESSAGE_ID = "message-textbox";
        public const string OBJECT_ID = "object-textbox";
        public const string OK_BUTTON_ID = "submit-button";
        public const string CANCEL_BUTTON_ID = "cancel-button";

        public static void GoTo()
        {
            PageNavigator.Coordinator.InviteCompanies.Select();
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

        public static void FillEmailFields(string messageObject, string message)
        {
            Driver.Instance.FindElement(By.Id(OBJECT_ID)).SendKeys(messageObject);
            Driver.Instance.FindElement(By.Id(MESSAGE_ID)).SendKeys(message); ;
        }

        public static void ClearEmailFields()
        {
            Driver.Instance.FindElement(By.Id(OBJECT_ID)).Clear();
            Driver.Instance.FindElement(By.Id(MESSAGE_ID)).Clear();
        }

        public static void Submit()
        {
            Driver.Instance.FindElement(By.Id(OK_BUTTON_ID)).Click();
        }

        public static void Cancel()
        {
            Driver.Instance.FindElement(By.Id(CANCEL_BUTTON_ID)).Click();
        }
    }

}
