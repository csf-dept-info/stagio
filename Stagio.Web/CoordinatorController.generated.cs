// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
#pragma warning disable 1591, 3008, 3009
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Stagio.Web.Controllers
{
    public partial class CoordinatorController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CoordinatorController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ValidateImport()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ValidateImport);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult InternshipPeriodDetails()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InternshipPeriodDetails);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CoordinatorController Actions { get { return MVC.Coordinator; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Coordinator";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Coordinator";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string ImportStudent = "ImportStudent";
            public readonly string ValidateImport = "ValidateImport";
            public readonly string StudentsList = "StudentsList";
            public readonly string ChooseInternshipPeriod = "ChooseInternshipPeriod";
            public readonly string CleanDatabase = "CleanDatabase";
            public readonly string InternshipsPeriodsList = "InternshipsPeriodsList";
            public readonly string InternshipPeriodDetails = "InternshipPeriodDetails";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string ImportStudent = "ImportStudent";
            public const string ValidateImport = "ValidateImport";
            public const string StudentsList = "StudentsList";
            public const string ChooseInternshipPeriod = "ChooseInternshipPeriod";
            public const string CleanDatabase = "CleanDatabase";
            public const string InternshipsPeriodsList = "InternshipsPeriodsList";
            public const string InternshipPeriodDetails = "InternshipPeriodDetails";
        }


        static readonly ActionParamsClass_ImportStudent s_params_ImportStudent = new ActionParamsClass_ImportStudent();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ImportStudent ImportStudentParams { get { return s_params_ImportStudent; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ImportStudent
        {
            public readonly string file = "file";
        }
        static readonly ActionParamsClass_ValidateImport s_params_ValidateImport = new ActionParamsClass_ValidateImport();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ValidateImport ValidateImportParams { get { return s_params_ValidateImport; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ValidateImport
        {
            public readonly string importStudents = "importStudents";
        }
        static readonly ActionParamsClass_ChooseInternshipPeriod s_params_ChooseInternshipPeriod = new ActionParamsClass_ChooseInternshipPeriod();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChooseInternshipPeriod ChooseInternshipPeriodParams { get { return s_params_ChooseInternshipPeriod; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChooseInternshipPeriod
        {
            public readonly string vmChoosePeriod = "vmChoosePeriod";
        }
        static readonly ActionParamsClass_CleanDatabase s_params_CleanDatabase = new ActionParamsClass_CleanDatabase();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CleanDatabase CleanDatabaseParams { get { return s_params_CleanDatabase; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CleanDatabase
        {
            public readonly string cleanDatabaseVm = "cleanDatabaseVm";
        }
        static readonly ActionParamsClass_InternshipPeriodDetails s_params_InternshipPeriodDetails = new ActionParamsClass_InternshipPeriodDetails();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_InternshipPeriodDetails InternshipPeriodDetailsParams { get { return s_params_InternshipPeriodDetails; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_InternshipPeriodDetails
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _PeriodIndexTablePartial = "_PeriodIndexTablePartial";
                public readonly string _StudentIndexTablePartial = "_StudentIndexTablePartial";
                public readonly string ChooseInternshipPeriod = "ChooseInternshipPeriod";
                public readonly string CleanDatabase = "CleanDatabase";
                public readonly string ImportStudent = "ImportStudent";
                public readonly string Index = "Index";
                public readonly string InternshipPeriodsDetails = "InternshipPeriodsDetails";
                public readonly string PeriodsList = "PeriodsList";
                public readonly string StudentsList = "StudentsList";
                public readonly string ValidateImport = "ValidateImport";
            }
            public readonly string _PeriodIndexTablePartial = "~/Views/Coordinator/_PeriodIndexTablePartial.cshtml";
            public readonly string _StudentIndexTablePartial = "~/Views/Coordinator/_StudentIndexTablePartial.cshtml";
            public readonly string ChooseInternshipPeriod = "~/Views/Coordinator/ChooseInternshipPeriod.cshtml";
            public readonly string CleanDatabase = "~/Views/Coordinator/CleanDatabase.cshtml";
            public readonly string ImportStudent = "~/Views/Coordinator/ImportStudent.cshtml";
            public readonly string Index = "~/Views/Coordinator/Index.cshtml";
            public readonly string InternshipPeriodsDetails = "~/Views/Coordinator/InternshipPeriodsDetails.cshtml";
            public readonly string PeriodsList = "~/Views/Coordinator/PeriodsList.cshtml";
            public readonly string StudentsList = "~/Views/Coordinator/StudentsList.cshtml";
            public readonly string ValidateImport = "~/Views/Coordinator/ValidateImport.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_CoordinatorController : Stagio.Web.Controllers.CoordinatorController
    {
        public T4MVC_CoordinatorController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ImportStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ImportStudent()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ImportStudent);
            ImportStudentOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ImportStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Web.HttpPostedFileBase file);

        [NonAction]
        public override System.Web.Mvc.ActionResult ImportStudent(System.Web.HttpPostedFileBase file)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ImportStudent);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "file", file);
            ImportStudentOverride(callInfo, file);
            return callInfo;
        }

        [NonAction]
        partial void ValidateImportOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Collections.Generic.IEnumerable<Stagio.Web.ViewModels.Coordinator.ImportStudentViewModel> importStudents);

        [NonAction]
        public override System.Web.Mvc.ActionResult ValidateImport(System.Collections.Generic.IEnumerable<Stagio.Web.ViewModels.Coordinator.ImportStudentViewModel> importStudents)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ValidateImport);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "importStudents", importStudents);
            ValidateImportOverride(callInfo, importStudents);
            return callInfo;
        }

        [NonAction]
        partial void StudentsListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult StudentsList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.StudentsList);
            StudentsListOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ChooseInternshipPeriodOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChooseInternshipPeriod()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChooseInternshipPeriod);
            ChooseInternshipPeriodOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ChooseInternshipPeriodOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Coordinator.ChoosePeriod vmChoosePeriod);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChooseInternshipPeriod(Stagio.Web.ViewModels.Coordinator.ChoosePeriod vmChoosePeriod)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChooseInternshipPeriod);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "vmChoosePeriod", vmChoosePeriod);
            ChooseInternshipPeriodOverride(callInfo, vmChoosePeriod);
            return callInfo;
        }

        [NonAction]
        partial void CleanDatabaseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CleanDatabase()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CleanDatabase);
            CleanDatabaseOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CleanDatabaseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Coordinator.CleanDatabase cleanDatabaseVm);

        [NonAction]
        public override System.Web.Mvc.ActionResult CleanDatabase(Stagio.Web.ViewModels.Coordinator.CleanDatabase cleanDatabaseVm)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CleanDatabase);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cleanDatabaseVm", cleanDatabaseVm);
            CleanDatabaseOverride(callInfo, cleanDatabaseVm);
            return callInfo;
        }

        [NonAction]
        partial void InternshipsPeriodsListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult InternshipsPeriodsList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InternshipsPeriodsList);
            InternshipsPeriodsListOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void InternshipPeriodDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult InternshipPeriodDetails(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InternshipPeriodDetails);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            InternshipPeriodDetailsOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
