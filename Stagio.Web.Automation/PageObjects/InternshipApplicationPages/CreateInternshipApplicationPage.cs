using System;
using Stagio.Web.Automation.Selenium;
using Stagio.TestUtilities;
using OpenQA.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipApplicationPages
{
    public class CreateInternshipApplicationPage
    {
        public static void GoTo()
        {
            const int OFFER_ID = 1;

            InternshipOfferPages.StudentIndexInternshipOfferPage.CreateInternshipApplication(OFFER_ID);
        }

        public static bool IsDisplayed()
        {
            try
            {
                Driver.Instance.FindElement(By.Id("application-create-page"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void UploadFile(string pdfFile)
        {
            UploadTestFiles(pdfFile);
            Driver.Instance.FindElement(By.Id("confirm-button")).Click();
        }

        private static void UploadTestFiles(String filename)
        {
            var fullPath = FileUtilities.GetPathFromFileName(filename);

            Driver.Instance.FindElement(By.Id("Resume")).SendKeys(fullPath);
            Driver.Instance.FindElement(By.Id("CoverLetter")).SendKeys(fullPath);
        }
    }
}
