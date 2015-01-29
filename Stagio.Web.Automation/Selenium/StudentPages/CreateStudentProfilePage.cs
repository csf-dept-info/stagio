using System;
using OpenQA.Selenium;
using Stagio.Domain.Entities;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.StudentPages
{
    public class CreateStudentProfilePage
    {
        public static void GoTo()
        {
            PageNavigator.Student.CreateStudentProfile.Select();
        }

        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("student-create-profile-page"));
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

        public static void FillForm(Student student)
        {
            Driver.Instance.FindElement(By.Id("NewPassword")).SendKeys(student.Password);
            Driver.Instance.FindElement(By.Id("ConfirmPassword")).SendKeys(student.Password);
            Driver.Instance.FindElement(By.Id("Identifier")).SendKeys(student.Identifier);
        }

        public static void Submit()
        {
            Driver.Instance.FindElement(By.Id("submit-create-profile")).Click();
        }
    }
}
