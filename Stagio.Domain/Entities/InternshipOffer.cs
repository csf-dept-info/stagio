using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stagio.Domain.Entities
{
    public class InternshipOffer : Entity
    {
        public enum OfferStatus { Publicated, OnValidation, Draft, Refused }

        public DateTime PublicationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfTrainees { get; set; }
        public DateTime Deadline { get; set; }
        public OfferStatus Status { get; set; }
        public string PathToExtraFile { get; set; }
        public int OfferOwnerId { get; set; }

        //Foreign keys
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [ForeignKey("Contact")]
        public int? ContactId { get; set; }
        [ForeignKey("OtherContact")]
        public int? OtherContactId { get; set; }
        [ForeignKey("PersonInCharge")]
        public int? PersonInChargeId { get; set; }
        
        //Navigation properties
        public virtual Company Company { get; set; }
        public virtual InternshipOfferDetails Details { get; set; }
        public virtual StaffMember Contact { get; set; }
        public virtual StaffMember OtherContact { get; set; }  
        public virtual StaffMember PersonInCharge { get; set; }

        public virtual ICollection<InternshipApplication> InternshipApplications { get; set; }

    }
}
