using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stagio.Domain.Entities
{
    public class Notification : Entity
    {
        public virtual ApplicationUser Receiver { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public string Object { get; set; }
        public bool Unseen { get; set; }
        public DateTime Time { get; set; }
        public string LinkController { get; set; }
        public string LinkAction { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }
    }
}
