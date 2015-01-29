using System;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;
using OpenQA.Selenium;


namespace Stagio.Web.Automation.PageObjects.EmployeePages
{
    public class CreateEmployeePage
    {
        public const string PAGE_ID = "employee-create-page";
        public const string PAGE_TITLE = "Création d'un compte Stagio pour un employé d'une entreprise";

        public static void GoTo()
        {
            PageNavigator.Employee.Create.Select();
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

        public static void FillCreationFormWith(Employee employee)
        {
            Driver.Instance.FindElement(By.Id("FirstName")).SendKeys(employee.FirstName);
            Driver.Instance.FindElement(By.Id("LastName")).SendKeys(employee.LastName);
            Driver.Instance.FindElement(By.Id("PhoneNumber")).SendKeys(employee.PhoneNumber);
            Driver.Instance.FindElement(By.Id("ExtensionNumber")).SendKeys(employee.ExtensionNumber);
            Driver.Instance.FindElement(By.Id("Identifier")).SendKeys(employee.Identifier);
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(employee.Password);
            Driver.Instance.FindElement(By.Id("ConfirmPassword")).SendKeys(employee.Password);
            Driver.Instance.FindElement(By.Id("create-btn")).Click();
        }

        public static void SelectAnExistingCompany()
        {
            Driver.Instance.FindElement(By.LinkText("Sélectionnez votre entreprise")).Click();
            Driver.Instance.FindElement(By.LinkText(TestData.Company1.Name)).Click();
            Driver.Instance.FindElement(By.Id("continue-employee-subscribe-process-button")).Click();
        }

        public static void SelectCreateNewCompany()
        {
            Driver.Instance.FindElement(By.LinkText("Sélectionnez votre entreprise")).Click();
            Driver.Instance.FindElement(By.LinkText("Nouvelle entreprise...")).Click();
            Driver.Instance.FindElement(By.Id("continue-employee-subscribe-process-button")).Click();
        }
    }
}
