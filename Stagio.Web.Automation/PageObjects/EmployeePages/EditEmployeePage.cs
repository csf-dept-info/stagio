using System;
using Stagio.Domain.Entities;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;
using OpenQA.Selenium;


namespace Stagio.Web.Automation.PageObjects.EmployeePages
{
    public class EditEmployeePage
    {
        public const string PAGE_ID = "employee-edit-page";

        public static void GoTo()
        {
            PageNavigator.Employee.EditProfile.Select();
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

        public static bool HasContent(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.ClassName("form-horizontal"));

            return body.Text.Contains(textToFind);
        }

        public static Employee FirstEmployee
        {
            get
            {
                return CreateEmployeeFromFieldsValue();
            }
        }

        public static void ModifyEmployeeProfileWith(Employee employee)
        {
            ClearEmployeeProfileFields();
            FillEmployeeProfileFieldsWith(employee);
            Driver.Instance.FindElement(By.Id("submit_profile_button")).Click();
        }

        public static void ModifyEmployeePasswordWith(string newPassword, string currentPassword)
        {
            ClearEmployeePasswordFields();
            FillEmployeePasswordFieldsWith(currentPassword, newPassword);
            Driver.Instance.FindElement(By.Id("submit_password_button")).Click();
        }

        public static void ClearEmployeeProfileFields()
        {
            Driver.Instance.FindElement(By.Id("PhoneNumber")).Clear();
            Driver.Instance.FindElement(By.Id("ExtensionNumber")).Clear();
            Driver.Instance.FindElement(By.Id("Identifier")).Clear();
        }

        private static void FillEmployeeProfileFieldsWith(Employee employee)
        {
            Driver.Instance.FindElement(By.Id("PhoneNumber")).SendKeys(employee.PhoneNumber);
            Driver.Instance.FindElement(By.Id("ExtensionNumber")).SendKeys(employee.ExtensionNumber);
            Driver.Instance.FindElement(By.Id("Identifier")).SendKeys(employee.Identifier);
        }

        public static void ClearEmployeePasswordFields()
        {
            Driver.Instance.FindElement(By.Id("Password")).Clear();
            Driver.Instance.FindElement(By.Id("NewPassword")).Clear();
            Driver.Instance.FindElement(By.Id("ConfirmPassword")).Clear();
        }

        private static void FillEmployeePasswordFieldsWith(string currentPassword, string newPassword)
        {
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(currentPassword);
            Driver.Instance.FindElement(By.Id("NewPassword")).SendKeys(newPassword);
            Driver.Instance.FindElement(By.Id("ConfirmPassword")).SendKeys(newPassword);
        }

        private static Employee CreateEmployeeFromFieldsValue()
        {
            return new Employee
            {
                FirstName = Driver.Instance.FindElement(By.Id("FirstName")).GetAttribute("value"),
                LastName = Driver.Instance.FindElement(By.Id("LastName")).GetAttribute("value"),
                Identifier = Driver.Instance.FindElement(By.Id("Identifier")).GetAttribute("value"),
                PhoneNumber = Driver.Instance.FindElement(By.Id("PhoneNumber")).GetAttribute("value"),
                ExtensionNumber = Driver.Instance.FindElement(By.Id("ExtensionNumber")).GetAttribute("value"),
            };
        }
    }
}
