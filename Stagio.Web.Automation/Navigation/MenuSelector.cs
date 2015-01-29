using Stagio.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Stagio.Web.Automation.Navigation
{
    public class MenuSelector
    {
        public static void SelectTopLevel(string topLevelMenuId)
        {
            var menuElement = Driver.Instance.FindElement(By.Id(topLevelMenuId));
            menuElement.Click();
        }
        public static void Select(string topLevelMenuId, string subLevelMenuId)
        {
            SelectTopLevel(topLevelMenuId);

            var menuItem = Driver.Instance.FindElement(By.Id(subLevelMenuId));
            menuItem.Click();
        }
    }
}
