using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrainingManagementRestAPI.Models
{
    public partial class TblResource
    {
        public TblResource()
        {
            TblResourceEnquiry = new HashSet<TblResourceEnquiry>();
        }

        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public decimal? ResourceFees { get; set; }
        public bool? IsActive { get; set; }
        public string ResourceDescription { get; set; }

        public virtual ICollection<TblResourceEnquiry> TblResourceEnquiry { get; set; }
    }
}
