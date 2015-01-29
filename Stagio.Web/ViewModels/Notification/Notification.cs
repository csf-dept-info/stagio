using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stagio.Domain.Entities;

namespace Stagio.Web.ViewModels.Notification
{
    public class Notification
    {
        [HiddenInput]
        public int Id { get; set; }
        [HiddenInput]
        public virtual ApplicationUser Receiver { get; set; }
        [HiddenInput]
        public bool Unseen { get; set; }

        public virtual ApplicationUser Sender { get; set; }
        public string Object { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime Time { get; set; }
        public string Link { get; set; }

        public string FormatTime()
        {
            return Time.ToString("MMM d");
        }
        
    }
}