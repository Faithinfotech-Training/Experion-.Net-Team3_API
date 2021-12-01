using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblResourceEnquiry
    {
        public int ResourceEnquiryId { get; set; }
        public int? ResourceId { get; set; }
        public int? LeadId { get; set; }
        public string ResourceEnquiryStatus { get; set; }
        public DateTime? ResourceEnqiryDate { get; set; }

        public virtual TblLead Lead { get; set; }
        public virtual TblResource Resource { get; set; }
    }
}
