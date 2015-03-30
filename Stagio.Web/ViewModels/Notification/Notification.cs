using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName(displayName: WebMessage.NotificationMessage.DISPLAY_SEEN)]
        [HiddenInput]
        public bool Unseen { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        [DisplayName(displayName: WebMessage.NotificationMessage.DISPLAY_OBJECT)]
        public string Object { get; set; }

        [DisplayName(displayName: WebMessage.NotificationMessage.DISPLAY_DATE)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime Time { get; set; }
        public string Link { get; set; }

        public string FormatTime()
        {
            return Time.ToString("MMM d");
        }
        
    }
}