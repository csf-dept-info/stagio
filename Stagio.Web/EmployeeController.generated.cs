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
    public partial class EmployeeController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected EmployeeController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult Create()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditProfile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditProfile);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditPassword()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditPassword);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public EmployeeController Actions { get { return MVC.Employee; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Employee";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Employee";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Create = "Create";
            public readonly string Edit = "Edit";
            public readonly string EditProfile = "Edit";
            public readonly string EditPassword = "Edit";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string EditProfile = "Edit";
            public const string EditPassword = "Edit";
        }


        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string selectedCompanyId = "selectedCompanyId";
            public readonly string employeeVm = "employeeVm";
        }
        static readonly ActionParamsClass_EditProfile s_params_EditProfile = new ActionParamsClass_EditProfile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditProfile EditProfileParams { get { return s_params_EditProfile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditProfile
        {
            public readonly string _employeeViewModel = "_employeeViewModel";
        }
        static readonly ActionParamsClass_EditPassword s_params_EditPassword = new ActionParamsClass_EditPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditPassword EditPasswordParams { get { return s_params_EditPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditPassword
        {
            public readonly string _employeeViewModel = "_employeeViewModel";
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
                public readonly string Create = "Create";
                public readonly string Edit = "Edit";
                public readonly string Index = "Index";
            }
            public readonly string Create = "~/Views/Employee/Create.cshtml";
            public readonly string Edit = "~/Views/Employee/Edit.cshtml";
            public readonly string Index = "~/Views/Employee/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_EmployeeController : Stagio.Web.Controllers.EmployeeController
    {
        public T4MVC_EmployeeController() : base(Dummy.Instance) { }

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
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int selectedCompanyId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(int selectedCompanyId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "selectedCompanyId", selectedCompanyId);
            CreateOverride(callInfo, selectedCompanyId);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Employee.Create employeeVm);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(Stagio.Web.ViewModels.Employee.Create employeeVm)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "employeeVm", employeeVm);
            CreateOverride(callInfo, employeeVm);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            EditOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EditProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Employee.Edit _employeeViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditProfile(Stagio.Web.ViewModels.Employee.Edit _employeeViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "_employeeViewModel", _employeeViewModel);
            EditProfileOverride(callInfo, _employeeViewModel);
            return callInfo;
        }

        [NonAction]
        partial void EditPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Employee.Edit _employeeViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditPassword(Stagio.Web.ViewModels.Employee.Edit _employeeViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "_employeeViewModel", _employeeViewModel);
            EditPasswordOverride(callInfo, _employeeViewModel);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108
