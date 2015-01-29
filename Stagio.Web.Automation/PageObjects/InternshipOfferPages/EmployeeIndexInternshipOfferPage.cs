using System;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;
using OpenQA.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipOfferPages
{
    public class EmployeeIndexInternshipOfferPage
    {
        public const string PAGE_ID = "internship-offer-employee-index-page";
        public const string PAGE_TITLE = "Offres de stage pour mon entreprise";

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

        public static int GetTotalOffersCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("offers-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static int GetRefusedOffersCount()
        {
            var refusedCount = Driver.Instance.FindElement(By.Name("refused-count")).GetAttribute("value");

            return int.Parse(refusedCount);
        }

        public static int GetDraftOffersCount()
        {
            var draftCount = Driver.Instance.FindElement(By.Name("draft-count")).GetAttribute("value");

            return int.Parse(draftCount);
        }

        public static int GetOnValidationOffersCount()
        {
            var onvalidationCount = Driver.Instance.FindElement(By.Name("onvalidation-count")).GetAttribute("value");

            return int.Parse(onvalidationCount);
        }

        public static int GetPublicatedOffersCount()
        {
            var publicatedCount = Driver.Instance.FindElement(By.Name("publicated-count")).GetAttribute("value");

            return int.Parse(publicatedCount);
        }

        public static void ClickDraft()
        {
            Driver.Instance.FindElement(By.Id("draft-tab")).Click();
        }

        public static void EditDraft(int firstOfferIndex)
        {
            Driver.Instance.FindElement(By.Id("internship-offer-edit-" + firstOfferIndex)).Click();
        }
    }
}
