using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblLead
    {
        public TblLead()
        {
            TblCourseEnquiry = new HashSet<TblCourseEnquiry>();
            TblResourceEnquiry = new HashSet<TblResourceEnquiry>();
            TblSalesPipeline = new HashSet<TblSalesPipeline>();
            TblTrainee = new HashSet<TblTrainee>();
        }

        public int LeadId { get; set; }
        public string LeadName { get; set; }
        public string Email { get; set; }
        public int? ContactNo { get; set; }
        public string Gender { get; set; }
        public string AddState { get; set; }
        public string City { get; set; }
        public int? Pincode { get; set; }
        public DateTime? Dob { get; set; }
        public string HighestQualification { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblCourseEnquiry> TblCourseEnquiry { get; set; }
        public virtual ICollection<TblResourceEnquiry> TblResourceEnquiry { get; set; }
        public virtual ICollection<TblSalesPipeline> TblSalesPipeline { get; set; }
        public virtual ICollection<TblTrainee> TblTrainee { get; set; }
    }
}
