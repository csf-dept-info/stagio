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
    public partial class InviteCompaniesController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected InviteCompaniesController(Dummy d) { }

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


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public InviteCompaniesController Actions { get { return MVC.InviteCompanies; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "InviteCompanies";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "InviteCompanies";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string InviteCompanies = "InviteCompanies";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string InviteCompanies = "InviteCompanies";
        }


        static readonly ActionParamsClass_InviteCompanies s_params_InviteCompanies = new ActionParamsClass_InviteCompanies();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_InviteCompanies InviteCompaniesParams { get { return s_params_InviteCompanies; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_InviteCompanies
        {
            public readonly string inviteCompaniesVm = "inviteCompaniesVm";
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
                public readonly string InviteCompanies = "InviteCompanies";
            }
            public readonly string InviteCompanies = "~/Views/InviteCompanies/InviteCompanies.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_InviteCompaniesController : Stagio.Web.Controllers.InviteCompaniesController
    {
        public T4MVC_InviteCompaniesController() : base(Dummy.Instance) { }

        [NonAction]
        partial void InviteCompaniesOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult InviteCompanies()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.InviteCompanies);
            InviteCompaniesOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void InviteCompaniesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.InviteCompanies.InviteCompanies inviteCompaniesVm);

        [NonAction]
        public override System.Web.Mvc.ActionResult InviteCompanies(Stagio.Web.ViewModels.InviteCompanies.InviteCompanies inviteCompaniesVm)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteCompanies);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "inviteCompaniesVm", inviteCompaniesVm);
            InviteCompaniesOverride(callInfo, inviteCompaniesVm);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
