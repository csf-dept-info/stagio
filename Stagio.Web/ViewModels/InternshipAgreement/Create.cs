using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.InternshipAgreement
{
    public class Create
    {
        [HiddenInput]
        public int Id { get; set; }

        public Stagio.Domain.Entities.InternshipApplication InternshipApplication { get; set; }

        #region CompanySection

        public Stagio.Domain.Entities.Company Company { get; set; }
        public Stagio.Domain.Entities.StaffMember PersonInCharge { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipAgreementMessage.REQUIRED_FIELD)]
        public string CompanyCommitmentMessage { get; set; }

        [DisplayName(WebMessage.InternshipAgreementMessage.CompanySection.REMUNERATED_LABEL)]
        public bool Remunerated { get; set; }

        [DisplayName(WebMessage.InternshipAgreementMessage.CompanySection.SIGN_LABEL)]
        public string EmployeeSignature { get; set; }

        [DisplayName("Date")]
        public DateTime? EmployeeSignedDate { get; set; }

        #endregion


        #region StudentSection

        [Required(ErrorMessage = WebMessage.InternshipAgreementMessage.REQUIRED_FIELD)]
        public string StudentCommitmentMessage { get; set; }
        
        [DisplayName(WebMessage.InternshipAgreementMessage.StudentSection.SIGN_LABEL)]
        public string StudentSignature { get; set; }

        [DisplayName("Date")]
        public DateTime? StudentSignedDate { get; set; }

        #endregion


        #region SchoolSection

        public Stagio.Web.ViewModels.InternshipOffer.StaffMember Coordinator { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipAgreementMessage.REQUIRED_FIELD)]
        public string SchoolCommitmentMessage { get; set; }

        [DisplayName(WebMessage.InternshipAgreementMessage.SchoolSection.SIGN_LABEL)]
        public string CoordinatorSignature { get; set; }

        [DisplayName("Date")]
        public DateTime? CoordinatorSignedDate { get; set; }

        #endregion
    }
}