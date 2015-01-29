using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Ploeh.AutoFixture;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.AcceptanceTests
{
    [TestClass]
    public class GlobalBaseTest
    {
        protected Fixture _fixture;

        [TestInitialize]
        public void GlobalInitialize()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            Driver.Initialize();

            Driver.Instance.FindElement(By.Id("go_home")).Click();
        }

        [TestCleanup]
        public void GlobalCleanup()
        {
            Driver.Close();
        }
    }
}

