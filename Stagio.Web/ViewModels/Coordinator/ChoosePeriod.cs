using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class ChoosePeriod
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [DisplayName(WebMessage.CoordinatorMessage.ChoosePeriod.START)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName(WebMessage.CoordinatorMessage.ChoosePeriod.END)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime EndDate { get; set; }
    }
}