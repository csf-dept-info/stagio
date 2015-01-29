using System;
using Stagio.Domain.Entities;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;
using OpenQA.Selenium;


namespace Stagio.Web.Automation.PageObjects.CompanyPages
{
    public class EditCompanyPage
    {
        public const string PAGE_ID = "company-edit-page";

        public static void GoTo()
        {
            PageNavigator.Company.EditProfile.Select();
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

        public static Company FirstCompany
        {
            get
            {
                return CreateCompanyFromFieldsValue();
            }
        }
        private static Company CreateCompanyFromFieldsValue()
        {
            return new Company
            {
                Name = Driver.Instance.FindElement(By.Id("Name")).GetAttribute("value"),
                Description = Driver.Instance.FindElement(By.Id("Description")).GetAttribute("value"),
                Address = Driver.Instance.FindElement(By.Id("Address")).GetAttribute("value"),
                PhoneNumber = Driver.Instance.FindElement(By.Id("PhoneNumber")).GetAttribute("value"),
                Email = Driver.Instance.FindElement(By.Id("Email")).GetAttribute("value"),
                WebSite = Driver.Instance.FindElement(By.Id("WebSite")).GetAttribute("value")
            };
        }
        public static void ModifyCompanyProfileWith(Company company)
        {
            ClearCompanyProfileFields();
            FillCompanyProfileFieldsWith(company);
            Driver.Instance.FindElement(By.Id("submitBtnProfile")).Click();
        }
        public static void ClearCompanyProfileFields()
        {
            Driver.Instance.FindElement(By.Id("Name")).Clear();
            Driver.Instance.FindElement(By.Id("Description")).Clear();
            Driver.Instance.FindElement(By.Id("Address")).Clear();
            Driver.Instance.FindElement(By.Id("PhoneNumber")).Clear();
            Driver.Instance.FindElement(By.Id("Email")).Clear();
            Driver.Instance.FindElement(By.Id("WebSite")).Clear();
        }
        private static void FillCompanyProfileFieldsWith(Company company)
        {
            Driver.Instance.FindElement(By.Id("Name")).SendKeys(company.Name);
            Driver.Instance.FindElement(By.Id("Description")).SendKeys(company.Description);
            Driver.Instance.FindElement(By.Id("Address")).SendKeys(company.Address);
            Driver.Instance.FindElement(By.Id("PhoneNumber")).SendKeys(company.PhoneNumber);
            Driver.Instance.FindElement(By.Id("Email")).SendKeys(company.Email);
            Driver.Instance.FindElement(By.Id("WebSite")).SendKeys(company.WebSite);
        }
    }
}
