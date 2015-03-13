using System;
using OpenQA.Selenium;
using Stagio.Domain.Entities;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.StudentPages
{
    public class EditStudentPage
    {
        public static void GoTo()
        {
            PageNavigator.Student.EditProfile.Select();
        }

        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("student_edit_page"));
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

        public static Student Student
        {
            get
            {
                return CreateStudentFromFieldsValue();
            }
        }

        public static void ModifyStudentProfileWith(Student student)
        {
            ClearStudentProfileFields();
            FillStudentProfileFieldsWith(student);
            Driver.Instance.FindElement(By.Id("submitBtnProfile")).Click();
        }

        public static void ModifyStudentPasswordWith(Student student, string newPassword)
        {
            ClearStudentPasswordFields();
            FillStudentPasswordFieldsWith(student, newPassword);
            Driver.Instance.FindElement(By.Id("submitBtnPassword")).Click();
        }

        public static void ClearStudentProfileFields()
        {
            Driver.Instance.FindElement(By.Id("PhoneNumber")).Clear();
            Driver.Instance.FindElement(By.Id("Identifier")).Clear();
        }

        private static void FillStudentProfileFieldsWith(ApplicationUser student)
        {
            Driver.Instance.FindElement(By.Id("PhoneNumber")).SendKeys(student.PhoneNumber);
            Driver.Instance.FindElement(By.Id("Identifier")).SendKeys(student.Identifier);
        }

        public static void ClearStudentPasswordFields()
        {
            Driver.Instance.FindElement(By.Id("Password")).Clear();
            Driver.Instance.FindElement(By.Id("NewPassword")).Clear();
            Driver.Instance.FindElement(By.Id("ConfirmPassword")).Clear();
        }

        private static void FillStudentPasswordFieldsWith(ApplicationUser employee, string newPassword)
        {
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(employee.Password);
            Driver.Instance.FindElement(By.Id("NewPassword")).SendKeys(newPassword);
            Driver.Instance.FindElement(By.Id("ConfirmPassword")).SendKeys(newPassword);
        }

        private static Student CreateStudentFromFieldsValue()
        {
            return new Student
            {
                FirstName = Driver.Instance.FindElement(By.Id("FirstName")).GetAttribute("value"),
                LastName = Driver.Instance.FindElement(By.Id("LastName")).GetAttribute("value"),
                Identifier = Driver.Instance.FindElement(By.Id("Identifier")).GetAttribute("value"),
                PhoneNumber = Driver.Instance.FindElement(By.Id("PhoneNumber")).GetAttribute("value"),
            };
        }
    }
}
