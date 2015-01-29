using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Stagio.Domain.Entities
{
    public class InternshipApplication : Entity
    {
        public enum ApplicationStatus
        {
            StudentHasApplied,
            StudentHadInterview,
            CompanyAcceptedStudent,
            StudentAcceptedOffer,
        }

        public string PathToResume { get; set; }
        public string PathToCoverLetter { get; set; }

        [ForeignKey("InternshipOffer")]
        public int InternshipOfferId { get; set; }
        public virtual InternshipOffer InternshipOffer { get; set; }

        [ForeignKey("ApplyingStudent")]
        public int StudentId { get; set; }
        public virtual Student ApplyingStudent { get; set; }

        public ApplicationStatus Progression { get; set; }

        public DateTime ApplicationDate { get; set; }

        public DateTime InterviewDate { get; set; }

        public DateTime CompanyAcceptedDate { get; set; }

        public DateTime StudentAcceptedDate { get; set; }

        public string GetCompanyName()
        {
            return this.InternshipOffer.Company.Name;
            }

        public string GetOfferTitle()
        {
            return this.InternshipOffer.Title;
        }

        public DateTime GetLastUpdateDate()
        {
            DateTime date = new DateTime();
            
            switch (this.Progression)
            {
                case ApplicationStatus.StudentHasApplied:
                    date = this.ApplicationDate;
                    break;
                case ApplicationStatus.StudentHadInterview:
                    date = this.InterviewDate;
                    break;
                case ApplicationStatus.CompanyAcceptedStudent:
                    date = this.CompanyAcceptedDate;
                    break;
                case ApplicationStatus.StudentAcceptedOffer:
                    date = this.StudentAcceptedDate;
                    break;
                default:
                    break;
            }

            return date;
        }
    }
}
