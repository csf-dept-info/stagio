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
    public partial class StudentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected StudentController(Dummy d) { }

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
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CreateProfile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateProfile);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public StudentController Actions { get { return MVC.Student; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Student";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Student";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Edit = "Edit";
            public readonly string EditProfile = "Edit";
            public readonly string EditPassword = "Edit";
            public readonly string SubscribeStudent = "SubscribeStudent";
            public readonly string CreateProfile = "CreateProfile";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Edit = "Edit";
            public const string EditProfile = "Edit";
            public const string EditPassword = "Edit";
            public const string SubscribeStudent = "SubscribeStudent";
            public const string CreateProfile = "CreateProfile";
        }


        static readonly ActionParamsClass_EditProfile s_params_EditProfile = new ActionParamsClass_EditProfile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditProfile EditProfileParams { get { return s_params_EditProfile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditProfile
        {
            public readonly string studentViewModel = "studentViewModel";
        }
        static readonly ActionParamsClass_EditPassword s_params_EditPassword = new ActionParamsClass_EditPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditPassword EditPasswordParams { get { return s_params_EditPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditPassword
        {
            public readonly string studentViewModel = "studentViewModel";
        }
        static readonly ActionParamsClass_SubscribeStudent s_params_SubscribeStudent = new ActionParamsClass_SubscribeStudent();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SubscribeStudent SubscribeStudentParams { get { return s_params_SubscribeStudent; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SubscribeStudent
        {
            public readonly string subscriber = "subscriber";
        }
        static readonly ActionParamsClass_CreateProfile s_params_CreateProfile = new ActionParamsClass_CreateProfile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateProfile CreateProfileParams { get { return s_params_CreateProfile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateProfile
        {
            public readonly string subscriber = "subscriber";
            public readonly string createProfile = "createProfile";
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
                public readonly string CreateProfile = "CreateProfile";
                public readonly string Edit = "Edit";
                public readonly string Index = "Index";
                public readonly string Subscribe = "Subscribe";
            }
            public readonly string CreateProfile = "~/Views/Student/CreateProfile.cshtml";
            public readonly string Edit = "~/Views/Student/Edit.cshtml";
            public readonly string Index = "~/Views/Student/Index.cshtml";
            public readonly string Subscribe = "~/Views/Student/Subscribe.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_StudentController : Stagio.Web.Controllers.StudentController
    {
        public T4MVC_StudentController() : base(Dummy.Instance) { }

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
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            EditOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EditProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Student.Edit studentViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditProfile(Stagio.Web.ViewModels.Student.Edit studentViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "studentViewModel", studentViewModel);
            EditProfileOverride(callInfo, studentViewModel);
            return callInfo;
        }

        [NonAction]
        partial void EditPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Student.Edit studentViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditPassword(Stagio.Web.ViewModels.Student.Edit studentViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "studentViewModel", studentViewModel);
            EditPasswordOverride(callInfo, studentViewModel);
            return callInfo;
        }

        [NonAction]
        partial void SubscribeStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult SubscribeStudent()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SubscribeStudent);
            SubscribeStudentOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void SubscribeStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Student.Subscribe subscriber);

        [NonAction]
        public override System.Web.Mvc.ActionResult SubscribeStudent(Stagio.Web.ViewModels.Student.Subscribe subscriber)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SubscribeStudent);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "subscriber", subscriber);
            SubscribeStudentOverride(callInfo, subscriber);
            return callInfo;
        }

        [NonAction]
        partial void CreateProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string subscriber);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateProfile(string subscriber)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "subscriber", subscriber);
            CreateProfileOverride(callInfo, subscriber);
            return callInfo;
        }

        [NonAction]
        partial void CreateProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Student.CreateProfile createProfile);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateProfile(Stagio.Web.ViewModels.Student.CreateProfile createProfile)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createProfile", createProfile);
            CreateProfileOverride(callInfo, createProfile);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
