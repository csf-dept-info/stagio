using System;
using OpenQA.Selenium;
using Stagio.Domain.Entities;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.Selenium;     

                                      
namespace Stagio.Web.Automation.PageObjects.StudentPages
{
    public class SubscribeStudentPage
    {
        public static void GoTo()
        {
            PageNavigator.Student.SubcribeStudent.Select();
        }

        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("student_subscribe_page"));
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

        public static void FillStudentIdWith(Student student)
        {
            Driver.Instance.FindElement(By.Id("StudentId")).SendKeys(student.StudentId);
        }

    }
}
