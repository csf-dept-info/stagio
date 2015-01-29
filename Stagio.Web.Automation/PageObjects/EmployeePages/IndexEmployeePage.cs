using Stagio.Web.Automation.Navigation;

namespace Stagio.Web.Automation.PageObjects.EmployeePages
{
    public class IndexEmployeePage
    {
        public static void GoTo()
        {
            PageNavigator.Employee.Index.Select();
        }
         
    }
}
