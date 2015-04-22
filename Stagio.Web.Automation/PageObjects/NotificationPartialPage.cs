using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects
{
    public class NotificationPartialPage
    {
        public static void GoTo()
        {
            PageNavigator.AllUsers.Notification.Select();
        }

        public static void ClickNotif(int i)
        {
            Driver.Instance.FindElement(By.Id(i.ToString())).Click();
        }
    }
}
