using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Stagio.Domain.Entities
{
    public class InternshipAgreement : Entity
    {
        [ForeignKey("InternshipApplication")]
        public int InternshipApplicationId { get; set; }
        public virtual InternshipApplication InternshipApplication { get; set; }


        #region CompanySection

        [ForeignKey("PersonInCharge")]
        public int PersonInChargeId { get; set; }
        public virtual StaffMember PersonInCharge { get; set; }
        public string CompanyCommitmentMessage { get; set; }
        public bool Remunerated { get; set; }
        
        public DateTime? EmployeeSignedDate { get; set; }

        #endregion


        #region StudentSection

        public string StudentCommitmentMessage { get; set; }
        public DateTime? StudentSignedDate { get; set; }

        #endregion


        #region SchoolSection
        [ForeignKey("Coordinator")]
        public int CoordinatorId { get; set; }
        public virtual StaffMember Coordinator { get; set; }
        public string SchoolCommitmentMessage { get; set; }
        public DateTime? CoordinatorSignedDate { get; set; }

        #endregion

    }
}
