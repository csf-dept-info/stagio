using System;

using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;

using OpenQA.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipOfferPages
{
    public class EmployeeIndexPublicatedInternshipOfferPage
    {
        public const string PAGE_ID = "internship-offer-employee-index-page";
        public const string PAGE_TITLE = "Offres de stage pour mon entreprise";

        public static void GoTo()
        {
            PageNavigator.InternshipOffer.EmployeeIndex.Select();
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

        public static int GetOffersCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("offers-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}
