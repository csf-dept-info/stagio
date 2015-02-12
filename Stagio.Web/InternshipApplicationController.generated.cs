// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
#pragma warning disable 1591, 3008, 3009, 0108
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
    public partial class InternshipApplicationController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected InternshipApplicationController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult GetApplicationsForSpecificStudent()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetApplicationsForSpecificStudent);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EmployeeApplicationIndex()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EmployeeApplicationIndex);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Create()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UpdateProgression()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateProgression);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DownloadFile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DownloadFile);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public InternshipApplicationController Actions { get { return MVC.InternshipApplication; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "InternshipApplication";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "InternshipApplication";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string StudentApplicationIndex = "StudentApplicationIndex";
            public readonly string GetApplicationsForSpecificStudent = "GetApplicationsForSpecificStudent";
            public readonly string EmployeeApplicationIndex = "EmployeeApplicationIndex";
            public readonly string CoordinatorApplicationIndex = "CoordinatorApplicationIndex";
            public readonly string Create = "Create";
            public readonly string UpdateProgression = "UpdateProgression";
            public readonly string DownloadFile = "DownloadFile";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string StudentApplicationIndex = "StudentApplicationIndex";
            public const string GetApplicationsForSpecificStudent = "GetApplicationsForSpecificStudent";
            public const string EmployeeApplicationIndex = "EmployeeApplicationIndex";
            public const string CoordinatorApplicationIndex = "CoordinatorApplicationIndex";
            public const string Create = "Create";
            public const string UpdateProgression = "UpdateProgression";
            public const string DownloadFile = "DownloadFile";
        }


        static readonly ActionParamsClass_GetApplicationsForSpecificStudent s_params_GetApplicationsForSpecificStudent = new ActionParamsClass_GetApplicationsForSpecificStudent();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetApplicationsForSpecificStudent GetApplicationsForSpecificStudentParams { get { return s_params_GetApplicationsForSpecificStudent; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetApplicationsForSpecificStudent
        {
            public readonly string studentId = "studentId";
        }
        static readonly ActionParamsClass_EmployeeApplicationIndex s_params_EmployeeApplicationIndex = new ActionParamsClass_EmployeeApplicationIndex();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EmployeeApplicationIndex EmployeeApplicationIndexParams { get { return s_params_EmployeeApplicationIndex; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EmployeeApplicationIndex
        {
            public readonly string offerId = "offerId";
        }
        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string internshipOfferId = "internshipOfferId";
            public readonly string applicationViewModel = "applicationViewModel";
        }
        static readonly ActionParamsClass_UpdateProgression s_params_UpdateProgression = new ActionParamsClass_UpdateProgression();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpdateProgression UpdateProgressionParams { get { return s_params_UpdateProgression; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpdateProgression
        {
            public readonly string item = "item";
        }
        static readonly ActionParamsClass_DownloadFile s_params_DownloadFile = new ActionParamsClass_DownloadFile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DownloadFile DownloadFileParams { get { return s_params_DownloadFile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DownloadFile
        {
            public readonly string path = "path";
            public readonly string offerId = "offerId";
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
                public readonly string CoordinatorIndex = "CoordinatorIndex";
                public readonly string Create = "Create";
                public readonly string EmployeeIndex = "EmployeeIndex";
                public readonly string StudentIndex = "StudentIndex";
            }
            public readonly string CoordinatorIndex = "~/Views/InternshipApplication/CoordinatorIndex.cshtml";
            public readonly string Create = "~/Views/InternshipApplication/Create.cshtml";
            public readonly string EmployeeIndex = "~/Views/InternshipApplication/EmployeeIndex.cshtml";
            public readonly string StudentIndex = "~/Views/InternshipApplication/StudentIndex.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_InternshipApplicationController : Stagio.Web.Controllers.InternshipApplicationController
    {
        public T4MVC_InternshipApplicationController() : base(Dummy.Instance) { }

        [NonAction]
        partial void StudentApplicationIndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult StudentApplicationIndex()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.StudentApplicationIndex);
            StudentApplicationIndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GetApplicationsForSpecificStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int studentId);

        [NonAction]
        public override System.Web.Mvc.ActionResult GetApplicationsForSpecificStudent(int studentId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetApplicationsForSpecificStudent);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "studentId", studentId);
            GetApplicationsForSpecificStudentOverride(callInfo, studentId);
            return callInfo;
        }

        [NonAction]
        partial void EmployeeApplicationIndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int offerId);

        [NonAction]
        public override System.Web.Mvc.ActionResult EmployeeApplicationIndex(int offerId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EmployeeApplicationIndex);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "offerId", offerId);
            EmployeeApplicationIndexOverride(callInfo, offerId);
            return callInfo;
        }

        [NonAction]
        partial void CoordinatorApplicationIndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CoordinatorApplicationIndex()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CoordinatorApplicationIndex);
            CoordinatorApplicationIndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int internshipOfferId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(int internshipOfferId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "internshipOfferId", internshipOfferId);
            CreateOverride(callInfo, internshipOfferId);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.InternshipApplication.Create applicationViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(Stagio.Web.ViewModels.InternshipApplication.Create applicationViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "applicationViewModel", applicationViewModel);
            CreateOverride(callInfo, applicationViewModel);
            return callInfo;
        }

        [NonAction]
        partial void UpdateProgressionOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.InternshipApplication.StudentIndex item);

        [NonAction]
        public override System.Web.Mvc.ActionResult UpdateProgression(Stagio.Web.ViewModels.InternshipApplication.StudentIndex item)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateProgression);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "item", item);
            UpdateProgressionOverride(callInfo, item);
            return callInfo;
        }

        [NonAction]
        partial void DownloadFileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string path, int offerId);

        [NonAction]
        public override System.Web.Mvc.ActionResult DownloadFile(string path, int offerId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DownloadFile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "path", path);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "offerId", offerId);
            DownloadFileOverride(callInfo, path, offerId);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108
