using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects.CoordinatorPages;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.Navigation
{
    public class PageNavigator
    {
        public class AllUsers
        {
            public class Home
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("home-link");
                }
            }

            public class Login
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("login-link");
                }
            }

            public class Logout
            {
                public static void Select()
                {
                    MenuSelector.Select("user-dropdown", "logout-link");
                }
            }

            public class Notification
            {
                public static void Select()
                {
                    MenuSelector.SelectTopLevel("notification-button");
                }
            }
        }

        public class Student
        {
            public class EditProfile
            {
                public static void Select()
                {
                    MenuSelector.Select("user-dropdown", "edit-profile-link");
                }
            }

            public class SubcribeStudent
            {
                public static void Select()
                {
                    Driver.Instance.FindElement(By.Id("subscribe-student")).Click();

                }
            }

            public class CreateStudentProfile 
            {
                public static void Select()
                {
                    Driver.Instance.FindElement(By.Id("create-student-button")).Click();
                }
            }
        }

        public class Employee
        {
            public class Index
            {
                public static void Select()
                {
                    MenuSelector.Select("user-dropdown", "index-link");
                }
            }

            public class Create
            {
                public static void Select()
                {
                    Driver.Instance.FindElement(By.Id("employee-create")).Click();
                }
            }

            public class EditProfile
            {
                public static void Select()
                {
                    MenuSelector.Select("user-dropdown", "edit-profile-link");
                }
            }
        }

        public class InternshipOffer
        {
            public class Index
            {
                public const string BUTTON_ID = "internship-offer-index-button";

                public static void Select()
                {
                    MenuSelector.SelectTopLevel(BUTTON_ID);
                }
            }

            public class EmployeeIndex
            {
                public const string BUTTON_TEXT = "Mes offres de stage";

                public static void Select()
                {
                    MenuSelector.SelectTopLevel(Index.BUTTON_ID);
                }
            }

            public class Details
            {
                public static void Select(int offerID)
                {
                    Driver.Instance.FindElement(By.Id("internship-offer-details-" + offerID)).Click();
                }
            }

            public class Create
            {
                public static void Select()
                {
                    Driver.Instance.FindElement(By.Id("intershipoffer-create-button")).Click();
                }
            }
        }

        public class Company
        {
            public class EditProfile
            {
                public static void Select()
                {
                    MenuSelector.Select("company-dropdown", "edit-company-link");
                }
            }
        }
        public class InternshipApplication
        {
            public class Create
            {
                public static void Select()
                {
                    Driver.Instance.FindElement(By.Id("internship-offer-student")).Click();
                }
            }

            public class EmployeeIndex
            {
                public const string BUTTON_TEXT = "Candidatures";
                public const string BUTTON_ID = "employee-index-internship-application-button";

                public static void Select()
                {
                    MenuSelector.SelectTopLevel(BUTTON_ID);
                    Driver.Instance.FindElement(By.Id("internship-offer-applications-1")).Click();
                }
            }

            public class CoordinatorIndex
            {
                public const string BUTTON_TEXT = "Candidatures";
                public const string BUTTON_ID = "coordinator-internship-applications-button";

                public static void Select()
                {
                    MenuSelector.SelectTopLevel(BUTTON_ID);
                    Driver.Instance.FindElement(By.Id("internship-offer-applications-1")).Click();
                }
            }

            public class StudentIndex
            {
                public const string BUTTON_TEXT = "Mes candidatures";
                public const string BUTTON_ID = "student-index-internship-application-button";

                public static void Select()
                {
                    MenuSelector.SelectTopLevel(BUTTON_ID);
                }
            }

            public class CoordinatorProgressionIndex
            {
                public const string BUTTON_TEXT = "Suivi des offres de stage";
                public const string BUTTON_ID = "progression-btn";
                public const string BUTTON_APPLICATIONS = "student-application-";

                public static void Select()
                {
                    MenuSelector.SelectTopLevel(BUTTON_ID);
                }

                public static void DisplayStudentApplications(int studentId)
                {
                    Driver.Instance.FindElement(By.Id(BUTTON_APPLICATIONS + studentId)).Click();
                }
            }
        }

        public class Coordinator
        {
            public class StudentsList
            {
                public static string PAGE_LINK
                {
                    get
                    {
                        return "students-list-button";
                    }
                }

                public static void Select()
                {
                    MenuSelector.Select("managing-dropdown", "students-list-link");
                }
            }

            public class ChoosePeriod
            {
                public static void Select()
                {
                    MenuSelector.Select("managing-dropdown", "choose-period-link");
                }
            }

            public class CleanDatabase
            {                      
                public static string PAGE_LINK
                {
                    get
                    {
                        return "clean-database-buton";
                    }
                }

                public static void Select()
                {
                    MenuSelector.Select("managing-dropdown", CleanDatabasePage.PAGE_ID);
                }
            }

            public class InviteCompanies
            {
                public static string PAGE_LINK
                {
                    get
                    {
                        return "invite-companies-button";
                    }
                }

                public static void Select()
                {
                    MenuSelector.Select("managing-dropdown", PageObjects.CoordinatorPages.InviteCompaniesPage.PAGE_ID);
                }
            }
        }
    }
}
