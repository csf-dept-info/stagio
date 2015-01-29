using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.TestUtilities.Database;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public partial class CiController : Controller
    {
        private readonly IDatabaseHelper _databaseHelper;

        public CiController(IDatabaseHelper dbInit)
        {
            if (dbInit == null) throw new NullReferenceException();
            _databaseHelper = dbInit;
        }

        // GET: Ci
        public virtual ActionResult Index()
        {
            try
            {
                DeleteDb();
                SeedDb();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return Content("BD remplie avec données de tests </Br> <a href=\"\\\" id='go_home'>Go home</a> ");

        }

        public virtual ActionResult CleanDatabase()
        {
            try
            {
                CleanDb();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            return RedirectToAction(MVC.Coordinator.Index());
        }

        private void DeleteDb()
        {
            SqlConnection.ClearAllPools();
            _databaseHelper.DeleteAll();
        }

        private void CleanDb()
        {
            _databaseHelper.CleanDatabase();
        }

        private static void SeedDb()
        {
            var testData = new DataBaseTestHelper();
            testData.SeedTables();
        }
    }
}
