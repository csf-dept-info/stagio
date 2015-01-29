using System.IO;
using System.Web;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Mappers;

using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.Controllers
{

    public class AllControllersBaseClassTests
    {
        protected Fixture _fixture;

        [TestInitialize]
        public void ControllerTestInit()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            AutoMapperConfiguration.Configure();

            InitializeHttpContext();
        }

        //Cette fonction nous permet de faire passer des FlashMessage dans les pages
        private void InitializeHttpContext()
        {
            HttpContext.Current = new HttpContext
            (
                new HttpRequest("", "http://cartel-progue.local", ""), 
                new HttpResponse(new StringWriter())
            );
        }
    }
}