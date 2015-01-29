using Stagio.Domain.Entities;
using Stagio.Web.Automation.Selenium;
using OpenQA.Selenium;


namespace Stagio.Web.Automation.PageObjects.CompanyPages
{
    public class CreateCompanyPage
    {
        public static void FillCompanyFieldsWith(Company company)
        {
            Driver.Instance.FindElement(By.Id("Name")).SendKeys(company.Name);
            Driver.Instance.FindElement(By.Id("Description")).SendKeys(company.Description);
            Driver.Instance.FindElement(By.Id("Address")).SendKeys(company.Address);
            Driver.Instance.FindElement(By.Id("PhoneNumber")).SendKeys(company.PhoneNumber);
            Driver.Instance.FindElement(By.Id("Email")).SendKeys(company.Email);
            Driver.Instance.FindElement(By.Id("WebSite")).SendKeys(company.WebSite);

            Driver.Instance.FindElement(By.Id("next-btn")).Click();
        }
    }
}
