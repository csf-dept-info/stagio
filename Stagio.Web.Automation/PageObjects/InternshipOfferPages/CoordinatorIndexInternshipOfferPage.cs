using System;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipOfferPages
{
    public class CoordinatorIndexInternshipOfferPage
    {
        public const string PAGE_ID = "internship-offer-coordinator-index-page";
        public const string PAGE_TITLE = "Offres de stage";

        public static void GoTo()
        {
            PageNavigator.InternshipOffer.Index.Select();
        }

        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("internship-offer-validation-index-page"));
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

        public static void ValidateInternshipOffer()
        {
            Driver.Instance.FindElement(By.Id("validate-button")).Click();
        }

        public static void DenyInternshipOffer()
        {
            Driver.Instance.FindElement(By.Id("deny-button")).Click();
            Driver.Instance.FindElement(By.Id("deny-message")).SendKeys("test");
            Driver.Instance.FindElement(By.Id("send-mail-btn")).Click();
        }
        public static int GetTotalOffersCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("offers-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}
