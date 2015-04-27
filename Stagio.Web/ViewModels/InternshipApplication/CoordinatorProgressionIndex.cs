using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.InternshipApplication
{
    public class CoordinatorProgressionIndex
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }

        [DisplayName(WebMessage.UserInformation.LAST_NAME)]
        public string LastName { get; set; }

        [DisplayName(WebMessage.UserInformation.FIRST_NAME)]
        public string FirstName { get; set; }

        public StudentIndex BestProgression { get; set; }
    }
}