﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class CleanDatabase
    {
        [DisplayName(WebMessage.GeneralMessage.PASSWORD)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}