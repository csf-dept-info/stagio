using System;
using Stagio.Domain.Entities;
using Stagio.Web.Automation.Selenium;
using Stagio.Web.Automation.Navigation;
using Stagio.TestUtilities;

using OpenQA.Selenium;

namespace Stagio.Web.Automation.PageObjects.InternshipOfferPages
{
    public class CreateInternshipOfferPage
    {
        public const string SUBMIT_BUTTON_ID = "create-button";
        public const string SAVE_DRAFT_BUTTON_ID = "save-draft-button";

        public static void GoTo()
        {
            PageNavigator.InternshipOffer.Create.Select();
        }

        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("internshipoffer-create-page"));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static void SubmitOffer()
        {
            Driver.Instance.FindElement(By.Id(SUBMIT_BUTTON_ID)).Click();
        }
        public static void SaveDraft()
        {
            Driver.Instance.FindElement(By.Id(SAVE_DRAFT_BUTTON_ID)).Click();
        }

        public static void FillCreationFormWith(InternshipOffer internshipOffer)
        {
            if (internshipOffer.Title != null)
            {
                Driver.Instance.FindElement(By.Id("Title")).SendKeys(internshipOffer.Title);
            }
            
            if (internshipOffer.Contact != null)
            {
                //We only need to fill this field for the contact because the rest is automatically added with the employee's information
                Driver.Instance.FindElement(By.Id("Contact_Title")).SendKeys(internshipOffer.Contact.Title);
            }

            if (internshipOffer.OtherContact != null)
            {
                FillStaffMemberFieldsWith("OtherContact", internshipOffer.OtherContact);
            }

            if (internshipOffer.Description != null)
            {
                Driver.Instance.FindElement(By.Id("Description")).SendKeys(internshipOffer.Description);
            }

            if (internshipOffer.Details != null)
            {
                FillDetailsFieldsWith("Details", internshipOffer.Details);
            }

            if (internshipOffer.PersonInCharge != null)
            {
                FillStaffMemberFieldsWith("PersonInCharge", internshipOffer.PersonInCharge);
            }

            if (internshipOffer.Deadline != null)
            {
                Driver.Instance.FindElement(By.Id("Deadline")).Clear();
                Driver.Instance.FindElement(By.Id("Deadline")).SendKeys(String.Format("{0:yyyy-MM-dd}", internshipOffer.Deadline.ToShortDateString()));
            }

            if (internshipOffer.PathToExtraFile != null)
            {
                UploadTestFile("TestFile.pdf");
            }
           
        }

        private static void FillStaffMemberFieldsWith(string parentField, StaffMember staffMember)
        {
            Driver.Instance.FindElement(By.Id(parentField + "_Name")).SendKeys(staffMember.Name);
            Driver.Instance.FindElement(By.Id(parentField + "_Title")).SendKeys(staffMember.Title);
            Driver.Instance.FindElement(By.Id(parentField + "_PhoneNumber")).SendKeys(staffMember.PhoneNumber);
            Driver.Instance.FindElement(By.Id(parentField + "_Email")).SendKeys(staffMember.Email);
        }

        private static void FillDetailsFieldsWith(string parentField, InternshipOfferDetails details)
        {
            Driver.Instance.FindElement(By.Id(parentField + "_SpecificHardwareAndSoftware")).SendKeys(details.SpecificHardwareAndSoftware);
            Driver.Instance.FindElement(By.Id(parentField + "_WorkingHours")).SendKeys(details.WorkingHours);
            Driver.Instance.FindElement(By.Id(parentField + "_HoursPerWeek")).SendKeys(details.HoursPerWeek);
            Driver.Instance.FindElement(By.Id(parentField + "_HourlyWage")).SendKeys(details.HourlyWage);
        }

        private static void UploadTestFile(String filename)
        {
            var fullPath = FileUtilities.GetPathFromFileName(filename);
            
            Driver.Instance.FindElement(By.Id("ExtraFile")).SendKeys(fullPath);
        }
        public static void ClickDeleteButton()
        {
            Driver.Instance.FindElement(By.Id("delete-draft-button")).Click();
        }

        public static void ClickModalDeleteButton()
        {
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.FindElement(By.Id("delete-draft-validation-button")).Click();
            Driver.Instance.SwitchTo().ActiveElement();
        }
    }
}
