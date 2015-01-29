using System;
using OpenQA.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipOfferPages
{
    public class StudentIndexInternshipOfferPage
    {
        public const string PAGE_ID = "internship-offer-student-index-page";
        public const string PAGE_TITLE = "Offres de stage disponibles";

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
                    Driver.Instance.FindElement(By.Id(PAGE_ID));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static void CreateInternshipApplication(int offerId)
        {
            Driver.Instance.FindElement(By.Id("internship-offer-details-" + offerId)).Click();
            Driver.Instance.FindElement(By.Id("apply-button")).Click();
        }
    }
}
